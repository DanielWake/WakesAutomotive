using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;

namespace WakesAutocare.Web.Controllers;

public class SitemapController : Controller
{
    private readonly AppDbContext _context;

    public SitemapController(AppDbContext context)
    {
        _context = context;
    }

    [Route("sitemap.xml")]
    [ResponseCache(Duration = 3600)] // Cache for 1 hour
    public async Task<IActionResult> Index()
    {
        var sb = new StringBuilder();
        sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
        sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");

        // Home page
        AddUrl(sb, Url.Action("Index", "Home", null, Request.Scheme), DateTime.UtcNow, "1.0", "daily");

        // About page
        AddUrl(sb, Url.Action("About", "Home", null, Request.Scheme), DateTime.UtcNow, "0.8", "monthly");

        // Contact page
        AddUrl(sb, Url.Action("Contact", "Home", null, Request.Scheme), DateTime.UtcNow, "0.8", "monthly");

        // Services
        var services = await _context.Services.Where(s => s.IsActive).ToListAsync();
        foreach (var service in services)
        {
            AddUrl(sb,
                Url.Action("Index", "Service", new { serviceSlug = service.Slug }, Request.Scheme),
                service.UpdatedAt,
                "0.9",
                "weekly");
        }

        // Locations
        var locations = await _context.Locations.Where(l => l.IsActive).ToListAsync();
        foreach (var location in locations)
        {
            AddUrl(sb,
                Url.Action("Index", "Location", new { locationSlug = location.Slug }, Request.Scheme),
                location.UpdatedAt,
                "0.9",
                "weekly");
        }

        // Service + Location pages
        var pages = await _context.ServiceLocationPages
            .Include(p => p.Service)
            .Include(p => p.Location)
            .Where(p => p.IsPublished)
            .ToListAsync();

        foreach (var page in pages)
        {
            AddUrl(sb,
                Url.Action("Location", "Service",
                    new { serviceSlug = page.Service.Slug, locationSlug = page.Location.Slug },
                    Request.Scheme),
                page.LastModified,
                "0.8",
                "weekly");
        }

        // Case Studies
        var caseStudies = await _context.CaseStudies.Where(cs => cs.IsPublished).ToListAsync();
        foreach (var caseStudy in caseStudies)
        {
            AddUrl(sb,
                Url.Action("Details", "CaseStudy", new { slug = caseStudy.Slug }, Request.Scheme),
                caseStudy.UpdatedAt,
                "0.7",
                "monthly");
        }

        sb.AppendLine("</urlset>");

        return Content(sb.ToString(), "application/xml", Encoding.UTF8);
    }

    private void AddUrl(StringBuilder sb, string? url, DateTime lastMod, string priority, string changeFreq)
    {
        if (string.IsNullOrEmpty(url))
            return;

        sb.AppendLine("  <url>");
        sb.AppendLine($"    <loc>{System.Net.WebUtility.HtmlEncode(url)}</loc>");
        sb.AppendLine($"    <lastmod>{lastMod:yyyy-MM-dd}</lastmod>");
        sb.AppendLine($"    <changefreq>{changeFreq}</changefreq>");
        sb.AppendLine($"    <priority>{priority}</priority>");
        sb.AppendLine("  </url>");
    }
}
