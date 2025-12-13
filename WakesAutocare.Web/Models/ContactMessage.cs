using System.ComponentModel.DataAnnotations;

namespace WakesAutocare.Web.Models;

public class ContactMessage
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Message { get; set; } = string.Empty;

    public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;

    public string? IpAddress { get; set; }
}
