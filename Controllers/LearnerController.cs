using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/learners")]
public class LearnerController(ILearnerService learnerService, IEventService eventService) : ControllerBase
{
    [HttpGet]
    [Route("{learnerId}")]
    public async Task<IActionResult> LearnerProfile([FromRoute] string learnerId)
    {
        if (string.IsNullOrEmpty(learnerId))
            return BadRequest("learnerId required");

        var result = await learnerService.GetLearnerProfile(learnerId);

        return Ok(result);
    }
    [HttpGet]
    [Route("{learnerId}/events")]
    public async Task<IActionResult> LearnersEvents([FromRoute] string learnerId)
    {
        if (string.IsNullOrEmpty(learnerId))
            return BadRequest("learnerId required");

        var result = await eventService.GetEvents(learnerId);

        return Ok(result);
    }
}