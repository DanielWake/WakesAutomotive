using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Services;

public interface ISeoService
{
    void SetMeta(string title, string? description = null, string? canonical = null);
    string BuildLocalBusinessJsonLd(ServiceLocationPage page, string businessPhone, string businessEmail);
    string BuildBreadcrumbJsonLd(List<(string name, string url)> breadcrumbs);
    string GenerateTitle(string serviceName, string locationName, string businessName);
    string GenerateMetaDescription(string serviceName, string locationName, string businessName);
}
