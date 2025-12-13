using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WakesAutocare.Web.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly IConfiguration _configuration;

    public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<bool> SendContactFormEmailAsync(string name, string email, string? phone, string message)
    {
        try
        {
            var businessEmail = _configuration["SiteSettings:Email"];
            var businessName = _configuration["SiteSettings:BusinessName"];

            // Log the contact form submission
            _logger.LogInformation(
                "Contact form submission received from {Name} ({Email}). Phone: {Phone}. Message: {Message}",
                name, email, phone ?? "Not provided", message);

            // TODO: Implement actual email sending using SMTP or email service (SendGrid, AWS SES, etc.)
            // For now, we're just logging and storing in database
            // When implementing, use configuration like:
            // var smtpHost = _configuration["EmailSettings:SmtpHost"];
            // var smtpPort = _configuration.GetValue<int>("EmailSettings:SmtpPort");
            // var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            // var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            // Example email content:
            // Subject: New Contact Form Submission - {businessName}
            // To: {businessEmail}
            // Body:
            // New contact form submission received
            //
            // Name: {name}
            // Email: {email}
            // Phone: {phone}
            // Message: {message}

            await Task.CompletedTask; // Placeholder for async email sending

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending contact form email");
            return false;
        }
    }
}
