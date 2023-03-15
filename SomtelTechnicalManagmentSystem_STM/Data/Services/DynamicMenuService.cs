using Microsoft.EntityFrameworkCore;
using SomtelTechnicalManagmentSystem_STM.Models.NavBarModel;
using SomtelTechnicalManagmentSystem_STM.ViewComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public class DynamicMenuService : IDynamicMenuService
    {
        private readonly AppDbContext _context;

       
        public DynamicMenuService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<NavbarParent>> GetAllAsync()
        {
            var results = await _context.NavbarParent.ToListAsync();
            return results;
        }
    }
}
