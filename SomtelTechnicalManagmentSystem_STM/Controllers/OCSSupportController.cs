using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SomtelTechnicalManagmentSystem_STM.Data.Services;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize(Roles = "OCS Mgr")]
    public class OCSSupportController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logs()
        {
            return View();
        }
    }
}
