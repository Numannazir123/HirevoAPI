using HirevoAPI.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HirevoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(
            IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET ALL JOBS
        [HttpGet]
        public async Task<IActionResult>
            GetAllJobs()
        {
            var jobs =
                await _jobService
                .GetAllJobsAsync();

            return Ok(jobs);
        }

        // GET JOB BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetJobById(int id)
        {
            var job =
                await _jobService
                .GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound(new
                {
                    message = "Job not found"
                });
            }

            return Ok(job);
        }
    }
}