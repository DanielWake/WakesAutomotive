using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Services;

namespace WakesAutocare.Web.Controllers;

public class CaseStudyController : Controller
{
    private readonly AppDbContext _context;
    private readonly ISeoService _seoService;

    public CaseStudyController(AppDbContext context, ISeoService seoService)
    {
        _context = context;
        _seoService = seoService;
    }

    // GET: /case-studies
    public async Task<IActionResult> Index()
    {
        _seoService.SetMeta(
            title: "Case Studies | Wakes Autocare",
            description: "Read about our recent automotive work. Real examples of diagnostics, repairs, servicing and more across Portsmouth and the South Coast.",
            canonical: Url.Action("Index", "CaseStudy", null, Request.Scheme)
        );

        var caseStudies = await _context.CaseStudies
            .Include(cs => cs.Service)
            .Where(cs => cs.IsPublished)
            .OrderByDescending(cs => cs.DatePublished)
            .ToListAsync();

        return View(caseStudies);
    }

    // GET: /case-studies/{slug}
    public async Task<IActionResult> Details(string slug)
    {
        var caseStudy = await _context.CaseStudies
            .Include(cs => cs.Service)
            .FirstOrDefaultAsync(cs => cs.Slug == slug && cs.IsPublished);

        if (caseStudy == null)
            return NotFound();

        var title = caseStudy.TitleTag ?? $"{caseStudy.Title} | Case Studies | Wakes Autocare";
        var description = caseStudy.MetaDescription ?? caseStudy.Summary;

        _seoService.SetMeta(
            title: title,
            description: description,
            canonical: Url.Action("Details", "CaseStudy", new { slug }, Request.Scheme)
        );

        // Get related case studies (same service)
        var relatedCaseStudies = await _context.CaseStudies
            .Where(cs =>
                cs.IsPublished &&
                cs.Id != caseStudy.Id &&
                cs.ServiceId == caseStudy.ServiceId)
            .OrderByDescending(cs => cs.DatePublished)
            .Take(3)
            .ToListAsync();

        ViewBag.RelatedCaseStudies = relatedCaseStudies;

        return View(caseStudy);
    }
}
