using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Data;

public static class ServiceLocationPageSeeder
{
    public static async Task SeedServiceLocationPages(AppDbContext context)
    {
        // Check if pages already exist
        if (context.ServiceLocationPages.Any())
        {
            return; // Already seeded
        }

        // Get all services and locations
        var services = await context.Services.Where(s => s.IsActive).ToListAsync();
        var locations = await context.Locations.Where(l => l.IsActive).ToListAsync();

        var pages = new List<ServiceLocationPage>();

        // Create a page for each service/location combination
        foreach (var service in services)
        {
            foreach (var location in locations)
            {
                var titleTag = GenerateTitleTag(service.Title, location.Name);
                var metaDescription = GenerateMetaDescription(service.Title, location.Name);
                var h1 = $"{service.Title} in {location.Name}";

                var page = new ServiceLocationPage
                {
                    ServiceId = service.Id,
                    LocationId = location.Id,
                    TitleTag = titleTag,
                    MetaDescription = metaDescription,
                    H1 = h1,
                    BodyHtml = "", // Will be generated from snippets
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                };

                pages.Add(page);
            }
        }

        await context.ServiceLocationPages.AddRangeAsync(pages);
        await context.SaveChangesAsync();
    }

    private static string GenerateTitleTag(string serviceName, string locationName)
    {
        // Keep under 60 characters for optimal SEO
        var title = $"{serviceName} in {locationName} | Wakes Autocare";

        if (title.Length > 60)
        {
            title = $"{serviceName} {locationName} | Wakes Autocare";
        }

        if (title.Length > 60)
        {
            // Shorten further if needed
            title = $"{serviceName} {locationName}";
        }

        return title;
    }

    private static string GenerateMetaDescription(string serviceName, string locationName)
    {
        // Keep under 160 characters for optimal SEO
        var description = $"Professional {serviceName.ToLower()} in {locationName}. IMI & ATA accredited technicians with 27 years experience. Mobile service available. Call 07544 064878";

        if (description.Length > 160)
        {
            description = $"Expert {serviceName.ToLower()} in {locationName}. IMI & ATA accredited. 27 years experience. Call 07544 064878";
        }

        return description;
    }
}
