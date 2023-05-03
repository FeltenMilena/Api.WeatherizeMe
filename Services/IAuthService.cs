using WeatherizeMe.DTOs;

namespace WeatherizeMe.Services
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }

}
