using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Services;

namespace WakesAutocare.Web.Controllers;

public class LocationController : Controller
{
    private readonly AppDbContext _context;
    private readonly ISeoService _seoService;

    public LocationController(AppDbContext context, ISeoService seoService)
    {
        _context = context;
        _seoService = seoService;
    }

    // GET: /locations/{locationSlug}
    public async Task<IActionResult> Index(string locationSlug)
    {
        var location = await _context.Locations
            .FirstOrDefaultAsync(l => l.Slug == locationSlug && l.IsActive);

        if (location == null)
            return NotFound();

        _seoService.SetMeta(
            title: $"Car Servicing & Repairs in {location.Name} | Wakes Autocare",
            description: $"Professional automotive services in {location.Name}, {location.County}. Full servicing, diagnostics, repairs and more. IMI & ATA accredited technicians.",
            canonical: Url.Action("Index", "Location", new { locationSlug }, Request.Scheme)
        );

        // Get all services
        var services = await _context.Services
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayOrder)
            .ToListAsync();

        ViewBag.Services = services;

        // Get nearby locations
        var nearbyLocations = await _context.Locations
            .Where(l => l.IsActive && l.Id != location.Id && l.County == location.County)
            .OrderBy(l => l.DisplayOrder)
            .Take(5)
            .ToListAsync();

        ViewBag.NearbyLocations = nearbyLocations;

        return View(location);
    }

    // GET: /locations
    public async Task<IActionResult> List()
    {
        _seoService.SetMeta(
            title: "Service Areas | Wakes Autocare",
            description: "We serve Portsmouth, Waterlooville, and the entire South Coast. Mobile service available across Hampshire and West Sussex.",
            canonical: Url.Action("List", "Location", null, Request.Scheme)
        );

        var locations = await _context.Locations
            .Where(l => l.IsActive)
            .OrderBy(l => l.County)
            .ThenBy(l => l.Name)
            .ToListAsync();

        return View(locations);
    }
}
