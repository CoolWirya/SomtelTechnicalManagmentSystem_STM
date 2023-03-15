using SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel;
using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<Login>> GetAllAsync();
        Task<Login> GetByIdAsync(int id);
        Task<Login> GetByUsername(string username);
        Task AddAsync(Login login);
        Task<Login> UpdateAsync(int id, Login newLogin);
        Task DeleteAsync(int id);
        Task NewUser(Login signup);
        Task<Login> CheckUserPassword(string inputPassword, string userName);
        Task<bool> CheckLoginNumberExists(string number);
        Task<bool> CheckLoginEmailExists(string email);
        Task<bool> CheckLoginUsernameExists(string username);
    }

}
