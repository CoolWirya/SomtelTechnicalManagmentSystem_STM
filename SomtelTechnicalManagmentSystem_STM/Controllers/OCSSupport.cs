using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize]
    public class OCSSupport : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
