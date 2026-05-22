using HirevoAPI.Contracts.IRepositories;
using HirevoAPI.Contracts.IServices;
using HirevoAPI.DataTransferObject;
using HirevoAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HirevoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration )
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        // REGISTER
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existingUser =
                await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return "Email already exists";
            }

            User user = new User()
            {
                FullName = dto.FullName,
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(user);

            return "User Registered Successfully";
        }

        // LOGIN
        public async Task<object> LoginAsync(LoginDto dto)
        {
            var user =
                await _userRepository
                .GetByUserNameAsync(dto.UserName);

            if (user == null)
            {
                return "Username not found";
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.Password);

            if (!isPasswordValid)
            {
                return "Invalid password";
            }

            var token = GenerateJwtToken(user);

            return new
            {
                token = token,
                username = user.Username
            };
        }
        // GET ALL USERS
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // GET USER BY ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // UPDATE USER
        public async Task<object> UpdateUserAsync(int id, RegisterDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return "User not found";
            }

            user.FullName = dto.FullName;
            user.Username = dto.Username;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            await _userRepository.UpdateUserAsync(user);

            return new
            {
                message = "User Updated Successfully",

                data = user
            };
        }

        // DELETE USER
        public async Task<string> DeleteUserAsync(int id)
        {
            var user =
                await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return "User not found";
            }

            await _userRepository.DeleteUserAsync(user);

            return "User Deleted Successfully";
        }
        private string GenerateJwtToken(User user)
        {
            var jwtSettings =
                _configuration.GetSection("Jwt");

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        jwtSettings["Key"]));

            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}