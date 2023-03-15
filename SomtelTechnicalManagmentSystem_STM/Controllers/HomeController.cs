using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SomtelTechnicalManagmentSystem_STM.Data.Services;
using SomtelTechnicalManagmentSystem_STM.Models;
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

        public async Task<IActionResult> ValidateLoginCredentials(string username, string password, string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if ((username == "bob" || username == "ahmed") && password == "pizza" )
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username)); //Just to know that you can create your own claim
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username)); 
                claims.Add(new Claim(ClaimTypes.Name, "Bon Edward Jones"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                claims.Add(new Claim(ClaimTypes.Email, "ismail@gmail.com"));
                claims.Add(new Claim(ClaimTypes.MobilePhone, "659000707"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); 
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); 
                await HttpContext.SignInAsync(claimsPrincipal); 
               
                return Redirect(returnUrl);
            }
            TempData["Error"] = "User is invalid";
            return View("login");
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
