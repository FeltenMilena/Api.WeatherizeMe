using WeatherizeMe.Models;

namespace WeatherizeMe.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
