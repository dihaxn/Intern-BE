using JWT_Test.Models;

namespace JWT_Test.Services
{
    public interface IJwtService
    {
        string GenerateToken(string username);
    }
}
