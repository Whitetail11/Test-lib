using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLayer.Interfaces;
using OnlineLibrary.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var res = await this.userService.Register(model);
            if(!res.Succeeded)
            {
                return BadRequest(res.Error);
            }
            return Ok(res.Token);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var res = await this.userService.Login(model);
            if(!res.Succeeded)
            {
                return BadRequest(res.Error);
            }
            return Ok(res.Token);
        }
    }
}
