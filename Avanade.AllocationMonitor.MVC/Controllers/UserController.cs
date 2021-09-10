using Avanade.AllocationMonitor.Core.BusinessLayers;
using Avanade.AllocationMonitor.Core.DependencyContainers;
using Avanade.AllocationMonitor.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthenticationBusinessLayer bl;
        public UserController()
        {
            bl = DependencyContainer.Resolve<AuthenticationBusinessLayer>();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userVm)
        {
            if (userVm == null)
                return View();

            var account = bl.GetUserByUserName(userVm.Username);
            if (account != null && ModelState.IsValid)
            {
                if (account.Password.Equals(userVm.Password))
                {
                    
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, account.IsAdministrator.ToString()),
                        new Claim(ClaimTypes.Name, account.UserName.ToString())

                    };
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = userVm.ReturnUrl
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                    );
                    return Redirect($"Home/Index/{userVm.Username}");
                }
                else
                {
                    ModelState.AddModelError(nameof(userVm.Password), "Invalid Password");
                    return View(userVm);
                }
            }
            return View(userVm);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("login");
        }

    }
}