using EdTetch.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/dashboard")]
public class DashboardController(IDashboardServices dashboardService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDashboard([FromQuery] string learnerId)
    {
        if (string.IsNullOrEmpty(learnerId))
            learnerId = "Guest";

        var result = await dashboardService.GetDashboardAsync(learnerId);

        return Ok(result);
    }
}