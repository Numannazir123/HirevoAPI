using HirevoAPI.Models;

namespace HirevoAPI.Contracts.IRepository
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetJobByIdAsync(int id);
    }
}