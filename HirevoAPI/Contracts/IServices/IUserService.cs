using HirevoAPI.DataTransferObject;
using HirevoAPI.Models;

namespace HirevoAPI.Contracts.IServices
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto dto);

        Task<object> LoginAsync(LoginDto dto);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<object> UpdateUserAsync(int id, RegisterDto dto);

        Task<string> DeleteUserAsync(int id);
    }
}