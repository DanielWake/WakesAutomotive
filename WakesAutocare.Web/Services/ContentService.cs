using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Services;

public class ContentService : IContentService
{
    private readonly AppDbContext _context;

    public ContentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> GeneratePageContent(ServiceLocationPage page, List<ContentSnippet> snippets)
    {
        if (!string.IsNullOrEmpty(page.BodyHtml))
        {
            // If custom content exists, use it
            return page.BodyHtml;
        }

        // Otherwise, generate content from snippets
        var contentBuilder = new System.Text.StringBuilder();

        foreach (var snippet in snippets)
        {
            contentBuilder.AppendLine($"<div class='content-snippet snippet-{snippet.Type.ToString().ToLower()}'>");
            contentBuilder.AppendLine(snippet.Content);
            contentBuilder.AppendLine("</div>");
        }

        // Add local facts if available
        if (!string.IsNullOrEmpty(page.LocalFacts))
        {
            contentBuilder.AppendLine($"<div class='local-facts'>");
            contentBuilder.AppendLine(page.LocalFacts);
            contentBuilder.AppendLine("</div>");
        }

        return contentBuilder.ToString();
    }

    public async Task<List<ContentSnippet>> GetSnippetsForPage(int serviceId, int locationId, int count = 3)
    {
        // Get snippets specific to this service/location combination, or global snippets
        var snippets = await _context.ContentSnippets
            .Where(s => s.IsActive &&
                       ((s.ServiceId == serviceId && s.LocationId == locationId) || // Exact match
                        (s.ServiceId == serviceId && s.LocationId == null) ||       // Service-specific
                        (s.ServiceId == null && s.LocationId == locationId) ||      // Location-specific
                        (s.ServiceId == null && s.LocationId == null)))             // Global
            .OrderByDescending(s => s.ServiceId.HasValue && s.ServiceId == serviceId ? 3 : 0) // Prioritize service-specific
            .ThenByDescending(s => s.LocationId.HasValue && s.LocationId == locationId ? 2 : 0) // Then location-specific
            .ThenBy(s => s.DisplayOrder)
            .Take(count)
            .ToListAsync();

        return snippets;
    }
}
