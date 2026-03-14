using EdTetch.Models;

public interface IRecommendationService
{
    List<CourseRecommendation> GetRecommedation(string segment, List<Events> events);
}