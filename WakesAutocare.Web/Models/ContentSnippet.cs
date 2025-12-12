using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public enum SnippetType
{
    Introduction,
    Feature,
    Testimonial,
    WhyChooseUs,
    ProcessDescription,
    CallToAction,
    LocalInfo
}

public class ContentSnippet
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public SnippetType Type { get; set; }

    [Required]
    public string Content { get; set; } = string.Empty;

    // Optional: Link to specific service (null = global snippet)
    public int? ServiceId { get; set; }

    // Optional: Link to specific location (null = global snippet)
    public int? LocationId { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Service? Service { get; set; }
    public Location? Location { get; set; }
}
