using Dapper;
using HirevoAPI.Contracts.IRepository;
using HirevoAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HirevoAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly IConfiguration _configuration;

        public JobRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(
                    _configuration
                    .GetConnectionString("MyConnection"));
            }
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            using var db = Connection;

            string query =
                "SELECT * FROM Jobs ORDER BY Id DESC";

            var jobs =
                await db.QueryAsync<Job>(query);

            return jobs.ToList();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            using var db = Connection;

            string query =
                "SELECT * FROM Jobs WHERE Id = @Id";

            var job =
                await db.QueryFirstOrDefaultAsync<Job>(
                    query,
                    new
                    {
                        Id = id
                    });

            return job;
        }
    }
}