using DataLayer.Models;
using OnlineLibrary.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<string> GenerateJWT(User user);
        Task<IEnumerable<Claim>> GetUserClaims(User user);
        Task<string> Register(RegisterViewModel model);
        Task<string> Login(LoginViewModel model);
    }
}
