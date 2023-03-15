using Microsoft.AspNetCore.Mvc;
using SomtelTechnicalManagmentSystem_STM.Data.Services;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.ViewComponents
{
    public class DynamicNavBarViewComponent : ViewComponent
    {
        private readonly IDynamicMenuService _dynamicMenuService;
        public DynamicNavBarViewComponent(IDynamicMenuService dynamicMenuService)
        {
            _dynamicMenuService = dynamicMenuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _dynamicMenuService.GetAllAsync();
            return View(menu);
        }
        //public async Task<IViewComponentResult> InVokeAsync()
        //{
        //    return View();
        //}
    }
}
