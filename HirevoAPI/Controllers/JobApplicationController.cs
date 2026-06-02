using HirevoAPI.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationController : ControllerBase
{
    private readonly IJobApplicationService _service;

    public JobApplicationController(
        IJobApplicationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> ApplyJob(
        int userId,
        int jobId)
    {
        var id = await _service.ApplyJobAsync(
            userId,
            jobId);

        return Ok(new
        {
            ApplicationId = id,
            Message = "Applied Successfully"
        });
    }
}