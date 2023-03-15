using SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public interface ISystemAlarmService
    {
        Task<IEnumerable<SystemAlarm>> GetAllAsync();
        Task<SystemAlarm> GetByIdAsync(int id);
        Task AddAsync(SystemAlarm systemAlarm);
        Task<SystemAlarm> UpdateAsync(int id, SystemAlarm newSystemAlarm);
        Task DeleteAsync(int id);
    }
}
