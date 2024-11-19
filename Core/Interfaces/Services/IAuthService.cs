using Core.Models;

namespace Core.Interfaces.Services;

public interface IAuthService
{
    string GenerateToken(User user);
}
