namespace HirevoAPI.DataTransferObject
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public DateTime TokenExpiry { get; set; }

        public UserDto User { get; set; } = new UserDto();
    }
}
