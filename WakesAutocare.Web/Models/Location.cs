using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public class Location
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string County { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? PostcodePrefix { get; set; }

    public string Description { get; set; } = string.Empty;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<ServiceLocationPage> ServiceLocationPages { get; set; } = new List<ServiceLocationPage>();
}
