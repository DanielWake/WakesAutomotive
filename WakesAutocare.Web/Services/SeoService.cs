using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Services;

public class SeoService : ISeoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SeoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetMeta(string title, string? description = null, string? canonical = null)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            httpContext.Items["Title"] = title;
            httpContext.Items["Description"] = description;
            httpContext.Items["Canonical"] = canonical;
        }
    }

    public string BuildLocalBusinessJsonLd(ServiceLocationPage page, string businessPhone, string businessEmail)
    {
        var jsonLd = new
        {
            context = "https://schema.org",
            type = "LocalBusiness",
            name = $"Wakes Autocare - {page.Service.Title} in {page.Location.Name}",
            image = "https://www.wakesautocare.co.uk/images/logo.jpg", // Update with actual domain
            telephone = businessPhone,
            email = businessEmail,
            address = new
            {
                type = "PostalAddress",
                addressLocality = page.Location.Name,
                addressRegion = page.Location.County,
                addressCountry = "GB",
                postalCode = page.Location.PostcodePrefix
            },
            geo = page.Location.Latitude.HasValue && page.Location.Longitude.HasValue
                ? new
                {
                    type = "GeoCoordinates",
                    latitude = page.Location.Latitude.Value,
                    longitude = page.Location.Longitude.Value
                }
                : null,
            url = page.CanonicalUrl ?? string.Empty,
            priceRange = "££",
            areaServed = new[]
            {
                new
                {
                    type = "City",
                    name = page.Location.Name
                },
                new
                {
                    type = "State",
                    name = page.Location.County
                }
            },
            openingHoursSpecification = new[]
            {
                new
                {
                    type = "OpeningHoursSpecification",
                    dayOfWeek = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" },
                    opens = "08:00",
                    closes = "17:00"
                },
                new
                {
                    type = "OpeningHoursSpecification",
                    dayOfWeek = new[] { "Saturday" },
                    opens = "08:00",
                    closes = "13:00"
                }
            },
            sameAs = new[]
            {
                "https://www.facebook.com/wakesautocare" // Update with actual social media
            }
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        return JsonSerializer.Serialize(jsonLd, options);
    }

    public string BuildBreadcrumbJsonLd(List<(string name, string url)> breadcrumbs)
    {
        var itemList = breadcrumbs.Select((bc, index) => new
        {
            type = "ListItem",
            position = index + 1,
            name = bc.name,
            item = bc.url
        }).ToList();

        var jsonLd = new
        {
            context = "https://schema.org",
            type = "BreadcrumbList",
            itemListElement = itemList
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        return JsonSerializer.Serialize(jsonLd, options);
    }

    public string GenerateTitle(string serviceName, string locationName, string businessName)
    {
        // Keep under 60 characters for optimal SEO
        var title = $"{serviceName} in {locationName} | {businessName}";

        if (title.Length > 60)
        {
            title = $"{serviceName} {locationName} | {businessName}";
        }

        return title;
    }

    public string GenerateMetaDescription(string serviceName, string locationName, string businessName)
    {
        // Keep under 160 characters for optimal SEO
        var description = $"Professional {serviceName.ToLower()} in {locationName}. {businessName} - IMI & ATA accredited technicians with 27 years experience. Mobile service available.";

        if (description.Length > 160)
        {
            description = $"Expert {serviceName.ToLower()} in {locationName}. IMI & ATA accredited. 27 years experience. Call 07544 064878";
        }

        return description;
    }
}
