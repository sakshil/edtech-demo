using EdTetch.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms")]
public class CmsControllers(ICmsService cmsService) : ControllerBase
{
    [HttpGet]
    [Route("dashboard")]
    public async Task<IActionResult> LearnerProfile([FromQuery] string segment)
    {
        if (string.IsNullOrEmpty(segment))
            return BadRequest("segment required");

        var result = await cmsService.GetCmsContent(segment);

        return Ok(result);
    }
}