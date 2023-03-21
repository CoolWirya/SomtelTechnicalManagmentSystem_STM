using SomtelTechnicalManagmentSystem_STM.Models.HWAlarmModel;
using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<Login>> GetAllAsync();
        Task<Login> GetByIdAsync(int id);
        Task<Login> GetByUsernameOrEmail(string usernameOrEmail);
        IEnumerable<string> GetRole(int id);

        Task<Login> GetByPhoneNumber(string phoneNumber);

        Task AddAsync(Login login);
        Task<Login> UpdateAsync(int id, Login newLogin);
        Task DeleteAsync(int id);
        Task<Dictionary<string, object>> AddNewUser(Login signup);
        Task<Login> CheckUserPassword(string inputPassword, string userName);
        Task<bool> CheckLoginNumberExists(string number);
        Task<bool> CheckLoginEmailExists(string email);
        Task<bool> CheckLoginUsernameExists(string username);
    }

}
