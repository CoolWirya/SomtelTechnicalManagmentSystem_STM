using SomtelTechnicalManagmentSystem_STM.Models.NavBarModel;
using SomtelTechnicalManagmentSystem_STM.ViewComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public interface IDynamicMenuService
    {
        Task<IEnumerable<NavbarParent>> GetAllAsync();

    }
}
