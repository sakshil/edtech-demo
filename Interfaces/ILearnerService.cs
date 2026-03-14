using EdTetch.Models;

public interface ILearnerService
{
    Task<LearnerProfile> GetLearnerProfile(string learnerId);
}