namespace EdTetch.Models
{
    public class DashboardResponse
    {
        public string CorrelationId { get; set; }
        public bool ServedFromCache { get; set; }
        public LearnerProfile Profile { get; set; }
        public List<CmsContent> Cms { get; set; }
        public List<CourseRecommendation> Recommendations { get; set; }
        public DashboardMeta Meta { get; set; }
    }

    public class DashboardMeta
    {
        public List<string> Errors { get; set; } = new();
    }
    public class LearnerProfile
    {
        public string LearnerID { get; set; }
        public string Grade { get; set; }
        public string Segment { get; set; }
        public string[] Interests { get; set; }
    }
    public class CmsContent
    {
        public string Segment { get; set; }
        public string BannerMessage { get; set; }
        public string Blocks { get; set; }
    }
    public class CourseRecommendation
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Score { get; set; }
    }
    public class Events
    {
        public string LearnerId { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
    }
    public class Catalog
    {
        public int CourseId { get; set; }
        public decimal BaseScore { get; set; }
        public decimal Score { get; set; }
        public string Tag { get; set; }
        public bool IsAdvanced { get; set; }
    }
}