using DataLayer.Models;
using OnlineLibrary.BusinessLayer.Classes;
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
        Task<AccountResult> Register(RegisterViewModel model);
        Task<AccountResult> Login(LoginViewModel model);
    }
}
