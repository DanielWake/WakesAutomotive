using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Models;
using WakesAutocare.Web.Services;

namespace WakesAutocare.Web.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ISeoService _seoService;
    private readonly IEmailService _emailService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        AppDbContext context,
        ISeoService seoService,
        IEmailService emailService,
        ILogger<HomeController> logger)
    {
        _context = context;
        _seoService = seoService;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        _seoService.SetMeta(
            title: "Wakes Autocare | Professional Vehicle Services in Portsmouth & South Coast",
            description: "Expert automotive services in Portsmouth and across the South Coast. IMI & ATA accredited technicians with 27 years combined experience. Mobile service available.",
            canonical: Url.Action("Index", "Home", null, Request.Scheme)
        );

        // Get featured services
        var services = await _context.Services
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayOrder)
            .Take(6)
            .ToListAsync();

        // Get featured case studies
        var caseStudies = await _context.CaseStudies
            .Where(cs => cs.IsPublished && cs.IsFeatured)
            .OrderByDescending(cs => cs.DatePublished)
            .Take(3)
            .ToListAsync();

        ViewBag.Services = services;
        ViewBag.CaseStudies = caseStudies;

        return View();
    }

    public IActionResult About()
    {
        _seoService.SetMeta(
            title: "About Us | Wakes Autocare",
            description: "Learn about Wakes Autocare. IMI & ATA accredited technicians with experience at Rolls Royce, BMW, Land Rover, Volkswagen, and Ford.",
            canonical: Url.Action("About", "Home", null, Request.Scheme)
        );

        return View();
    }

    public IActionResult Contact()
    {
        _seoService.SetMeta(
            title: "Contact Us | Wakes Autocare",
            description: "Get in touch with Wakes Autocare. Call 07544 064878 or email Wakesautocare@gmail.com. Based in Waterlooville, serving Portsmouth and the South Coast.",
            canonical: Url.Action("Contact", "Home", null, Request.Scheme)
        );

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(string name, string email, string? phone, string message)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
        {
            TempData["ErrorMessage"] = "Please fill in all required fields.";
            return RedirectToAction(nameof(Contact));
        }

        try
        {
            // Save contact message to database
            var contactMessage = new ContactMessage
            {
                Name = name.Trim(),
                Email = email.Trim(),
                Phone = phone?.Trim(),
                Message = message.Trim(),
                DateSubmitted = DateTime.UtcNow,
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString()
            };

            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();

            // Send email notification
            await _emailService.SendContactFormEmailAsync(name, email, phone, message);

            _logger.LogInformation("Contact form submitted successfully by {Email}", email);

            TempData["SuccessMessage"] = "Thank you for contacting us! We'll get back to you soon.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing contact form submission");
            TempData["ErrorMessage"] = "There was an error submitting your message. Please try again or call us directly.";
        }

        return RedirectToAction(nameof(Contact));
    }

    public IActionResult Error()
    {
        return View();
    }
}
