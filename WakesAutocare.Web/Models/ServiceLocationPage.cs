using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public class ServiceLocationPage
{
    public int Id { get; set; }

    // Foreign Keys
    public int ServiceId { get; set; }
    public int LocationId { get; set; }

    // SEO Fields - All editable in admin
    [MaxLength(60)]
    public string? TitleTag { get; set; }

    [MaxLength(160)]
    public string? MetaDescription { get; set; }

    [MaxLength(200)]
    public string? H1 { get; set; }

    public string BodyHtml { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? CanonicalUrl { get; set; }

    // Content snippet assignments (comma-separated IDs or JSON array)
    public string? ContentSnippetIds { get; set; }

    // Custom local facts for this location/service combination
    public string? LocalFacts { get; set; }

    // Publishing
    public bool IsPublished { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Service Service { get; set; } = null!;
    public Location Location { get; set; } = null!;
}
