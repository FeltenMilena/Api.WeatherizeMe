using WeatherizeMe.DTOs;
using WeatherizeMe.Models;
using Microsoft.AspNetCore.Identity;
using WeatherizeMe.Data;

namespace WeatherizeMe.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly MyDbContext _context;

        public UserService(UserManager<User> userManager, MyDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.OrderBy(u => u.Name).ToList();
        }

        public User GetById(string id)
        {
            return _context.Users.Find(id);
        }

        public User GetByUserName(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Name == username);
        }

        public async Task CreateUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.UserName,
                Email = userDto.Email,
            };
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Erro ao criar usuário.");
            }
        }

        public async Task UpdateUser(string id, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            user.Name = userDto.UserName;
            user.Email = userDto.Email;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Erro ao atualizar usuário.");
            }
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Erro ao excluir usuário.");
            }
        }
    }
}

