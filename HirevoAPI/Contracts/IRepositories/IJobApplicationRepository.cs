namespace HirevoAPI.Contracts.IRepositories
{
    public interface IJobApplicationRepository
    {
        Task<int> ApplyJobAsync(int userId, int jobId);
    }
}
