using HirevoAPI.Contracts.IRepository;
using HirevoAPI.Contracts.IServices;
using HirevoAPI.Models;

namespace HirevoAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetJobByIdAsync(id);
        }
    }
}