using HirevoAPI.Contracts.IRepositories;
using HirevoAPI.Contracts.IServices;

public class JobApplicationService : IJobApplicationService
{
    private readonly IJobApplicationRepository _repo;

    public JobApplicationService(
        IJobApplicationRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> ApplyJobAsync(
        int userId,
        int jobId)
    {
        return await _repo.ApplyJobAsync(
            userId,
            jobId);
    }
}