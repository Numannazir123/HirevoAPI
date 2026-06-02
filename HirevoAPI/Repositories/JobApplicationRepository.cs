using HirevoAPI.Contracts.IRepositories;
using HirevoAPI.Data;
using HirevoAPI.Models;

public class JobApplicationRepository : IJobApplicationRepository
{
    private readonly AppDbContext _context;

    public JobApplicationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> ApplyJobAsync(int userId, int jobId)
    {
        var application = new JobApplication
        {
            UserId = userId,
            JobId = jobId,
            AppliedDate = DateTime.Now
        };

        _context.JobApplications.Add(application);

        await _context.SaveChangesAsync();

        return application.ApplicationId;
    }
}