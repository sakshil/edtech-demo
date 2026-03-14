using EdTetch.Interfaces;
using EdTetch.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EdTetch.Services
{
    public class DashboardService(IMemoryCache cache, ILearnerService learnerService,
            IEventService eventService, ICmsService cmsService, IRecommendationService recommendationService,
            ILogger<DashboardService> logger, IHttpContextAccessor http) : IDashboardServices
    {
        public async Task<DashboardResponse> GetDashboardAsync(string learnerId)
        {
            var cacheKey = $"dashboard:{learnerId}";

            if (cache.TryGetValue(cacheKey, out DashboardResponse cached))
            {
                cached.ServedFromCache = true;
                return cached;
            }

            var correlationId = http.HttpContext.TraceIdentifier;

            var response = new DashboardResponse
            {
                CorrelationId = correlationId,
                ServedFromCache = false
            };

            try
            {
                var profile = await learnerService.GetLearnerProfile(learnerId);

                var eventsTask = eventService.GetEvents(learnerId);
                var cmsTask = cmsService.GetCmsContent(profile.Segment);

                await Task.WhenAll(eventsTask, cmsTask);

                var events = eventsTask.Result;

                response.Profile = profile;
                try
                {
                    response.Cms = cmsTask.Result;
                }
                catch (Exception)
                {
                    response.Meta.Errors.Add("CMS unavailable");
                }
                try
                {
                    response.Recommendations = recommendationService.GetRecommedation(profile.Segment, events);
                }
                catch (Exception)
                {
                    response.Meta.Errors.Add("Recommendation engine failed");
                }

            }
            catch
            {
                response.Meta.Errors.Add("Some Other error occured");
            }
            cache.Set(cacheKey, response, TimeSpan.FromSeconds(60));

            return response;
        }
    }
}