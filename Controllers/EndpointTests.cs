using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class EndpointTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;

    public EndpointTests(WebApplicationFactory<Program> factory)
    {
        client = factory
            .WithWebHostBuilder(builder =>
            {
                builder.UseContentRoot(Directory.GetCurrentDirectory());
            })
            .CreateClient();
    }

    [Fact]
    public async Task DashboardEndpoint_ShouldReturnDashboardData()
    {
        var response = await client.GetAsync("/api/v1/dashboard?learnerId=1");

        response.EnsureSuccessStatusCode();
    }
    [Fact]
    public async Task LearnerProfileEndpoint_ShouldReturnDashboardData()
    {
        var response = await client.GetAsync("/api/v1/learners/{1}");

        response.EnsureSuccessStatusCode();
    }
    [Fact]
    public async Task LearnerEventsEndpoint_ShouldReturnDashboardData()
    {
        var response = await client.GetAsync("/api/v1/learners/{1}/events");

        response.EnsureSuccessStatusCode();
    }
    [Fact]
    public async Task CmsEventsEndpoint_ShouldReturnDashboardData()
    {
        var response = await client.GetAsync("/api/v1/cms/dashboard?segment=free");

        response.EnsureSuccessStatusCode();
    }
}