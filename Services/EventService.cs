using EdTetch.Models;
using System.Text.Json;

namespace EdTetch.Services
{
    public class EventService() : IEventService
    {
        public Task<List<Events>> GetEvents(string learnerId)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Models", "BaseEvents.json");
            var json = File.ReadAllText(path);
            var events = JsonSerializer
                .Deserialize<List<Events>>(json)?
                .Where(x => x.LearnerId == learnerId)
                .ToList() ?? new List<Events>();

            return Task.FromResult(events);

        }
    }
}