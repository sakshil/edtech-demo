using EdTetch.Models;

public interface IEventService
{
    Task<List<Events>> GetEvents(string learnerId);
}