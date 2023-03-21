using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SomtelTechnicalManagmentSystem_STM.Data.Security;
using SomtelTechnicalManagmentSystem_STM.Data.Services;
using SomtelTechnicalManagmentSystem_STM.Models;
using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _service;

     

        public HomeController(ILogger<HomeController> logger, ILoginService service)
        {
            _logger = logger;
            _service = service;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }   
            else
            {
                return View("login");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }
        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<IActionResult> ValidateLoginCredentials(string usernameOrEmail, string password, string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl;
            var loginDetails = await _service.GetByUsernameOrEmail(usernameOrEmail);
            if (loginDetails != null)
            {
                
                Hash256 sha = new Hash256();
                string hash = sha.GenerateSHA256Hash(password, loginDetails.Salt);
                if(hash == loginDetails.Password)
                {
                    IEnumerable<string> getPermission = _service.GetRole(loginDetails.Id);
                    var claims = new List<Claim>();
                    //claims.Add(new Claim("username", loginDetails.UserName)); //Just to know that you can create your own claim
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, loginDetails.FullName));
                    claims.Add(new Claim(ClaimTypes.Name, loginDetails.FullName));
                    if (getPermission.Count() > 0)
                    {
                        foreach(var permissions in getPermission)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, permissions));
                        }
 
                    }

                    claims.Add(new Claim(ClaimTypes.Email, loginDetails.Email));
                    claims.Add(new Claim(ClaimTypes.MobilePhone, loginDetails.PhoneNumber));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    return Redirect(returnUrl);
                }
                else
                {
                    TempData["Error"] = "Password is wrong";
                    return View("login");
                }
              
            }
            else
            {
                TempData["Error"] = "User is invalid";
                return View("login");
            }
           
          
        }
        //[Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
