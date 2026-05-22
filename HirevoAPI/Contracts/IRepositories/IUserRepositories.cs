using HirevoAPI.Models;

namespace HirevoAPI.Contracts.IRepositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByUserNameAsync(string username);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}