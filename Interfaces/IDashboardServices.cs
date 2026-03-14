using EdTetch.Models;

namespace EdTetch.Interfaces
{
    public interface IDashboardServices
    {
        Task<DashboardResponse> GetDashboardAsync(string learnerId);
    }
}
