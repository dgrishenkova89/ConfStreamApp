namespace ConfStream.Contracts.Dto.Login
{
    public class LoginResponse
    {
        public string JwtToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
