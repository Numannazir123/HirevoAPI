using HirevoAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace HirevoAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    }
}
