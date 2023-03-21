using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SomtelTechnicalManagmentSystem_STM.Data.Security;
using System;

namespace SomtelTechnicalManagmentSystem_STM.Data.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;
        private readonly ISMSService _smsservice;
        

        public LoginService(AppDbContext context, ISMSService smsservice)
        {
            _context = context;
            _smsservice = smsservice;
            

        }
        public IQueryable<Login> LoginDbContext()
        {
            IQueryable<Login> IQcontext = _context.Logins.Where(n => n.DeleteFlag == false);
            return IQcontext;
        }
        public async Task AddAsync(Login login)
        {

            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();
        }

   

        public async Task DeleteAsync(int id)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.Id == id);
            _context.Logins.Remove(results);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Login>> GetAllAsync()
        {
            var results = await LoginDbContext().ToListAsync();
            return results;
        }

        public async Task<Login> GetByIdAsync(int id)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.Id == id);
            return results;
        }

        public async Task<Login> GetByUsernameOrEmail(string usernameOrEmail)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.Email == usernameOrEmail && n.Activate == true);
            if(results == null)
                results = await LoginDbContext().FirstOrDefaultAsync(n => n.UserName == usernameOrEmail && n.Activate == true);

            return results;
        }

        public async Task<Login> UpdateAsync(int id, Login newLogin)
        {
            _context.Logins.Update(newLogin);
            await _context.SaveChangesAsync();
            return newLogin;
        }


        public async Task<Dictionary<string,object>> AddNewUser(Login signup)
        {
            Dictionary<string, object> newUserDictionary = new Dictionary<string, object>();
            newUserDictionary.Add("UsernameIsOK", true);
            newUserDictionary.Add("EmailIsOK", true);
            newUserDictionary.Add("PhoneNumberIsOK", true);
            newUserDictionary.Add("Added", false);

            
            bool validatePhoneNumber = Validations.UserInputValidation.ValidatePhoneNumber(signup.PhoneNumber);
            if (!validatePhoneNumber)
                newUserDictionary["PhoneNumberIsOK"] = false;
            bool validateUsername = Validations.UserInputValidation.ValidateUserName(signup.UserName);
            if (!validateUsername)
                newUserDictionary["UsernameIsOK"] = false;
            bool validateEmail = Validations.UserInputValidation.ValidateEmail(signup.Email);
            if (!validateEmail)
                newUserDictionary["EmailIsOK"] = false;

            if (Convert.ToBoolean(newUserDictionary["PhoneNumberIsOK"]) == false || Convert.ToBoolean(newUserDictionary["UsernameIsOK"]) == false || Convert.ToBoolean(newUserDictionary["EmailIsOK"]) == false)
                return newUserDictionary;


            Random random = new Random();
            signup.OTP = random.Next(10000, 99999).ToString();
            signup.CreationDate = System.DateTime.Now;
           
            _smsservice.InsertSMS("SCHEDULED", "TTS", "252" + signup.PhoneNumber, "STM System", "OTP: " + signup.OTP);

            await AddAsync(signup);
            newUserDictionary["Added"] = true;
            return newUserDictionary;
        }
        public async Task<Login> CheckUserPassword(string inputPassword, string userName)
        {
            Hash256 sha = new Hash256();
            Login dbResults = await GetByUsernameOrEmail(userName);
            string dbHash = dbResults.Password;
            string dbSalt = dbResults.Salt;
            string userHash = sha.GenerateSHA256Hash(inputPassword, dbSalt);
            if (dbHash == userHash)
            {
                return dbResults;
            }
            else
            {
                return null;
            }

        }
        public async Task<bool> CheckLoginNumberExists(string number)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.PhoneNumber == number);
            if (results == null)
                return false;
            return true;
        }

        public async Task<bool> CheckLoginEmailExists(string email)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.Email == email);
            if (results == null)
                return false;
            return true;
        }
        public async Task<bool> CheckLoginUsernameExists(string username)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.UserName == username);
            if (results == null)
                return false;
            return true;
        }

        public async Task<Login> GetByPhoneNumber(string phoneNumber)
        {
            var results = await LoginDbContext().FirstOrDefaultAsync(n => n.PhoneNumber == phoneNumber);
            return results;
        }

        public IEnumerable<string> GetRole(int id)
        {
            IEnumerable<string> empty = new List<string> { ""};
            /*
             var results = from login in _context.Logins
                          join permission in _context.Privileges
                          on login.Id equals permission.LoginId
                          select new  {  permission.PermissionName };


            
            return results.Select(n => (n.PermissionName)).ToList();
            */

            return empty;

        }
    }
}
