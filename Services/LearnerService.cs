using EdTetch.Models;
using System.Text.Json;

namespace EdTetch.Services
{
    public class LearnerService() : ILearnerService
    {
        public Task<LearnerProfile> GetLearnerProfile(string learnerId)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Models", "LearnersProfiles.json");

            var json = File.ReadAllText(path);

            LearnerProfile profile = JsonSerializer
                .Deserialize<List<LearnerProfile>>(json)?
                .Where(x => x.LearnerID.Equals(learnerId, StringComparison.InvariantCultureIgnoreCase))
                 .FirstOrDefault() ?? new LearnerProfile
                 {
                     LearnerID = "Guest Users",
                     Grade = "0",
                     Segment = "Free"
                 };


            return Task.FromResult(profile);
        }
    }
}