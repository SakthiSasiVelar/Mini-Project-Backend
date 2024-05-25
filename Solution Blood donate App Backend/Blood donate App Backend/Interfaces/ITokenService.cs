using Blood_donate_App_Backend.Models;

namespace Blood_donate_App_Backend.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserAuthDetails userAuthDetails);
    }
}
