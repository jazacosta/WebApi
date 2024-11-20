using Core.Models;

namespace Core.Interfaces.Services;

public interface IAuthService   //for all post methods
{
    string CreateToken(User user);
    bool ValidateJwt(string token);
}
