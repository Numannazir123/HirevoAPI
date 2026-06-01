using HirevoAPI.Models;

namespace HirevoAPI.Contracts.IServices
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetJobByIdAsync(int id);
    }
}