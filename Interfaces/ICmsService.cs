using EdTetch.Models;

namespace EdTetch.Interfaces
{
    public interface ICmsService
    {
        Task<List<CmsContent>> GetCmsContent(string segment);
    }
}
