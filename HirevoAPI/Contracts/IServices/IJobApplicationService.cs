namespace HirevoAPI.Contracts.IServices
{
    public interface IJobApplicationService
    {
        Task<int> ApplyJobAsync(int userId, int jobId);
    }
}
