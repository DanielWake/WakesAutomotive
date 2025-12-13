namespace WakesAutocare.Web.Services;

public interface IEmailService
{
    Task<bool> SendContactFormEmailAsync(string name, string email, string? phone, string message);
}
