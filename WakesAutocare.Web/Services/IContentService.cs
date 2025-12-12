using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Services;

public interface IContentService
{
    Task<string> GeneratePageContent(ServiceLocationPage page, List<ContentSnippet> snippets);
    Task<List<ContentSnippet>> GetSnippetsForPage(int serviceId, int locationId, int count = 3);
}
