using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public class CaseStudy
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Summary { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    // SEO
    [MaxLength(60)]
    public string? TitleTag { get; set; }

    [MaxLength(160)]
    public string? MetaDescription { get; set; }

    // Related service (optional)
    public int? ServiceId { get; set; }

    // Images (JSON array of image paths)
    public string? Images { get; set; }

    // Featured image
    [MaxLength(500)]
    public string? FeaturedImage { get; set; }

    public bool IsFeatured { get; set; } = false;

    public bool IsPublished { get; set; } = true;

    public DateTime DatePublished { get; set; } = DateTime.UtcNow;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Service? Service { get; set; }
}
