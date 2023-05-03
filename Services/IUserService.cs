using Nest;
using WeatherizeMe.DTOs;
using WeatherizeMe.Models;

namespace WeatherizeMe.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        User GetByUserName(string name);
        Task CreateUser(UserDto userDto);
        Task UpdateUser(string id, UserDto userDto);
        Task DeleteUser(string id);
    }
}
