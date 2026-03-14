using EdTetch.Models;

namespace EdTetch.Services
{
    public class RecommendationService() : IRecommendationService
    {
        public List<CourseRecommendation> GetRecommedation(string segment, List<Events> events)
        {
            List<Catalog> catalog = new List<Catalog>()
            {
                new Catalog {CourseId=1,BaseScore=0.05m, Tag="Math", IsAdvanced=false},
                new Catalog {CourseId=2,BaseScore=0.02m, Tag="Science", IsAdvanced=false},
                new Catalog  {CourseId=3, BaseScore =0.08m, Tag="Coding", IsAdvanced=false},
            };
            foreach (var courseType in catalog)
            {
                decimal score = courseType.BaseScore;
                if (events.Any(e => e.Type.Equals("Search", StringComparison.InvariantCultureIgnoreCase) && e.Tag == courseType.Tag))
                {
                    score += 0.12m;
                }
                else if (events.Any(e => e.Type.Equals("View", StringComparison.InvariantCultureIgnoreCase) && e.Tag == courseType.Tag))
                {
                    score += 0.10m;
                }
                if (segment.Equals("paid", StringComparison.InvariantCultureIgnoreCase) && courseType.IsAdvanced)
                {
                    score += 0.05m;
                }
                courseType.Score = score;

            }
            return catalog
              .OrderByDescending(c => c.Score)
              .Take(5)
              .Select(c => new CourseRecommendation
              {
                  CourseId = c.CourseId,
                  Title = c.Tag,
                  Score = c.Score
              })
              .ToList();
        }
    }
}