using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SomtelTechnicalManagmentSystem_STM.Data.Services;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    [Authorize]
    public class HardwareAlarmsController : Controller
    {

        private readonly ISystemAlarmService _service;

        public HardwareAlarmsController(ISystemAlarmService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
