using EdTetch.Interfaces;
using EdTetch.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace EdTetch.Services
{
    public class CmsService(IMemoryCache cache) : ICmsService
    {
        public Task<List<CmsContent>> GetCmsContent(string segment)
        {
            var cacheKey = $"cmsContent:{segment.ToLower()}";

            if (cache.TryGetValue(cacheKey, out List<CmsContent>? cached) && cached != null)
            {
                return Task.FromResult(cached);
            }

            List<CmsContent> response;

            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "Models", "CmsContent.json");

                var json = File.ReadAllText(path);

                response = JsonSerializer
                    .Deserialize<List<CmsContent>>(json)?
                    .Where(x => x.Segment.Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                    .ToList() ?? new List<CmsContent>();
            }
            catch
            {
                response = new List<CmsContent>()
                {
                    new   CmsContent{Segment="Free",BannerMessage="Welcome to Ed Tech",Blocks = "Quizes" }
                };
            }

            cache.Set(cacheKey, response, TimeSpan.FromMinutes(10));

            return Task.FromResult(response);
        }

    }
}