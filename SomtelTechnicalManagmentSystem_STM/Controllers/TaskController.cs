using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
    }
}
