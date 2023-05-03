using System.Security.Cryptography;
using System.Text;
using WeatherizeMe.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;

    public AuthService(IUserService userService, IConfiguration configuration, ITokenService tokenService)
    {
        _userService = userService;
        _configuration = configuration;
        _tokenService = tokenService;
    }

    public async Task<string> Authenticate(string username, string password)
    {
        var user = _userService.GetByUserName(username);

        if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

        var token = _tokenService.GenerateToken(user);
        return token;
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i]) return false;
        }

        return true;
    }
}
