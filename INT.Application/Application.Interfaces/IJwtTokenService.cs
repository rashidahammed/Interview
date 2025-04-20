namespace INT.Application.Application.Interfaces
{
    public interface IJwtTokenService
    {
            string GenerateToken(long userId, string username, string email);
    }
}
