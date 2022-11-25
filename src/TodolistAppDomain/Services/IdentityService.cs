using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodolistAppAPI.Data;
using TodolistAppDomain.Helper;
using TodolistAppModels.Configs;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations;
using Task = System.Threading.Tasks.Task;

namespace TodolistAppDomain.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly TokenConfig _config;

        public IdentityService(IMapper mapper, DataContext context, IOptions<TokenConfig> config)
        {
            _mapper = mapper;
            _context = context;
            _config = config.Value;
        }

        public async Task CreateUser(UserInformation userInformation)
        {
            if (await _context.Users.AnyAsync(x => x.Username == userInformation.Username))
                throw new Exception("This username is already taken.");

            EncryptHelper.CreatePasswordHashAndSalt(userInformation.Password, out byte[] hash, out byte[] salt);

            var user = _mapper.Map<User>(userInformation);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetToken(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                throw new Exception("Username or password is wrong");

            if (!EncryptHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Username or password is wrong");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, EnumHelper.GetDescription(user.Role))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public Task<bool> Authorize(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
