using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineLibrary.BusinessLayer.Interfaces;
using OnlineLibrary.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public UserService(UserManager<User> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<Claim>> GetUserClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("userid", user.Id),
                new Claim("useremail", user.Email),
            };

            var userRoles = await userManager.GetRolesAsync(user);
            if (userRoles.Count != 0)
            {
                claims.Add(new Claim("role", userRoles.First()));
            }
            return claims;
        }
        public async Task<string> GenerateJWT(User user)
        {
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                notBefore: now,
                expires: DateTime.Now.AddHours(3),
                claims: await GetUserClaims(user),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Name);
            if (userExists != null)
                return "";
            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "";
            var token = await this.GenerateJWT(user);
            return token;
        }

        public async Task<string> Login(LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Name);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await this.GenerateJWT(user);
                return token;
            }
            return "";
        }
    }
}
