using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Services;

namespace WakesAutocare.Web.Controllers;

public class ServiceController : Controller
{
    private readonly AppDbContext _context;
    private readonly ISeoService _seoService;
    private readonly IContentService _contentService;
    private readonly IConfiguration _configuration;

    public ServiceController(
        AppDbContext context,
        ISeoService seoService,
        IContentService contentService,
        IConfiguration configuration)
    {
        _context = context;
        _seoService = seoService;
        _contentService = contentService;
        _configuration = configuration;
    }

    // GET: /services/{serviceSlug}
    public async Task<IActionResult> Index(string serviceSlug)
    {
        var service = await _context.Services
            .FirstOrDefaultAsync(s => s.Slug == serviceSlug && s.IsActive);

        if (service == null)
            return NotFound();

        _seoService.SetMeta(
            title: $"{service.Title} | Wakes Autocare",
            description: service.Summary,
            canonical: Url.Action("Index", "Service", new { serviceSlug }, Request.Scheme)
        );

        // Get locations where this service is offered
        var locations = await _context.Locations
            .Where(l => l.IsActive)
            .OrderBy(l => l.DisplayOrder)
            .ToListAsync();

        // Get related case studies
        var caseStudies = await _context.CaseStudies
            .Where(cs => cs.ServiceId == service.Id && cs.IsPublished)
            .OrderByDescending(cs => cs.DatePublished)
            .Take(3)
            .ToListAsync();

        ViewBag.Locations = locations;
        ViewBag.CaseStudies = caseStudies;

        return View(service);
    }

    // GET: /services/{serviceSlug}/{locationSlug}
    public async Task<IActionResult> Location(string serviceSlug, string locationSlug)
    {
        var page = await _context.ServiceLocationPages
            .Include(p => p.Service)
            .Include(p => p.Location)
            .FirstOrDefaultAsync(p =>
                p.Service.Slug == serviceSlug &&
                p.Location.Slug == locationSlug &&
                p.IsPublished);

        if (page == null)
        {
            // If no specific page exists, try to find the service and location
            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.Slug == serviceSlug && s.IsActive);

            var location = await _context.Locations
                .FirstOrDefaultAsync(l => l.Slug == locationSlug && l.IsActive);

            if (service == null || location == null)
                return NotFound();

            // Create a temporary page object for display
            page = new Models.ServiceLocationPage
            {
                Service = service,
                Location = location,
                ServiceId = service.Id,
                LocationId = location.Id
            };
        }

        // Generate SEO metadata
        var title = page.TitleTag ?? _seoService.GenerateTitle(
            page.Service.Title,
            page.Location.Name,
            "Wakes Autocare"
        );

        var description = page.MetaDescription ?? _seoService.GenerateMetaDescription(
            page.Service.Title,
            page.Location.Name,
            "Wakes Autocare"
        );

        var canonical = page.CanonicalUrl ?? Url.Action(
            "Location",
            "Service",
            new { serviceSlug, locationSlug },
            Request.Scheme
        );

        _seoService.SetMeta(title, description, canonical);

        // Generate JSON-LD structured data
        var businessPhone = _configuration["SiteSettings:Phone"] ?? "07544 064878";
        var businessEmail = _configuration["SiteSettings:Email"] ?? "Wakesautocare@gmail.com";
        var jsonLd = _seoService.BuildLocalBusinessJsonLd(page, businessPhone, businessEmail);
        ViewData["JsonLd"] = jsonLd;

        // Get content snippets
        var snippets = await _contentService.GetSnippetsForPage(page.ServiceId, page.LocationId);
        var content = await _contentService.GeneratePageContent(page, snippets);
        ViewBag.GeneratedContent = content;

        // Get related case studies
        var caseStudies = await _context.CaseStudies
            .Where(cs => cs.ServiceId == page.ServiceId && cs.IsPublished)
            .OrderByDescending(cs => cs.DatePublished)
            .Take(2)
            .ToListAsync();
        ViewBag.CaseStudies = caseStudies;

        return View(page);
    }
}
