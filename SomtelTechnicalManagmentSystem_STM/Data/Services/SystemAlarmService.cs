using SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public class SystemAlarmService : ISystemAlarmService
    {

        private readonly AppDbContext _context;

        public SystemAlarmService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SystemAlarm systemAlarm)
        {
            await _context.SystemAlarms.AddAsync(systemAlarm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var results = await _context.SystemAlarms.FirstOrDefaultAsync(n => n.Id == id);
            _context.SystemAlarms.Remove(results);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SystemAlarm>> GetAllAsync()
        {
            var results = await _context.SystemAlarms.ToListAsync();
            return results;
        }

        public async Task<SystemAlarm> GetByIdAsync(int id)
        {
            var results = await _context.SystemAlarms.FirstOrDefaultAsync(n => n.Id == id);
            return results;
        }

        public async Task<SystemAlarm> UpdateAsync(int id, SystemAlarm newSystemAlarm)
        {
            _context.SystemAlarms.Update(newSystemAlarm);
            await _context.SaveChangesAsync();
            return newSystemAlarm;
        }
    }
}
