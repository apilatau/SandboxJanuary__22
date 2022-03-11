using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appSettings = new AppSettings();
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
        {
            var data = await _userRepository.ListAsync();
            var user = data.Where(x => x.TelegramId == model.TelegramId).FirstOrDefault();
            var roles = await _roleRepository.ListAsync();
            var role = roles.Where(x => x.Id == user.RoleId).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user, role);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user, Role role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Role, role.RoleName),
                    new Claim(ClaimTypes.Name, user.TelegramId.ToString())
                }),
                Issuer = "JWTAuthenticationIssuer",
                Audience = "JWTAuthenticationAudience",
                Expires = DateTime.UtcNow.AddMinutes(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task DeleteAsync(User user) => await _userRepository.DeleteAsync(user);

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task UpdateAsync(User user) => await _userRepository.UpdateAsync(user);
    }
}