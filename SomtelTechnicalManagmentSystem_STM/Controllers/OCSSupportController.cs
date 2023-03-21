using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize]
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
