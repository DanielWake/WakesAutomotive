using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public class Service
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

    public string Description { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Icon { get; set; } = string.Empty; // e.g., "fa-wrench", "fa-diagnostics"

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<ServiceLocationPage> ServiceLocationPages { get; set; } = new List<ServiceLocationPage>();
    public ICollection<CaseStudy> CaseStudies { get; set; } = new List<CaseStudy>();
}
