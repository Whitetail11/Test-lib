using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineLibrary.BusinessLayer.Classes;
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
        private async Task<IEnumerable<Claim>> GetUserClaims(User user)
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
        private async Task<string> GenerateJWT(User user)
        {
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                notBefore: now,
                expires: now.AddHours(3),
                claims: await GetUserClaims(user),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AccountResult> Register(RegisterViewModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Name);
            if (userExists != null)
                return new AccountResult(new List<string>() { "User already exists!" });
            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(error => error.Description);
                return new AccountResult(errors);
            }
            var token = await this.GenerateJWT(user);
            return new AccountResult(true, token);
        }

        public async Task<AccountResult> Login(LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Name);
            if (user == null)
                return new AccountResult(new List<string>() { "User not found!" });
            if (!(await userManager.CheckPasswordAsync(user, model.Password)))
                return new AccountResult(new List<string>() { "Uncorrect password" });            
            var token = await this.GenerateJWT(user);
            return new AccountResult(true, token);
        }
    }
}
