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

        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Login login)
        {
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.Id == id);
            _context.Logins.Remove(results);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Login>> GetAllAsync()
        {
            var results = await _context.Logins.ToListAsync();
            return results;
        }

        public async Task<Login> GetByIdAsync(int id)
        {
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.Id == id);
            return results;
        }

        public async Task<Login> GetByUsername(string username)
        {
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.UserName == username);
            return results;
        }

        public async Task<Login> UpdateAsync(int id, Login newLogin)
        {
            _context.Logins.Update(newLogin);
            await _context.SaveChangesAsync();
            return newLogin;
        }


        public async Task NewUser(Login signup)
        {
            //Hash256 sha = new Hash256();
            //string salt = sha.CreateSalt(10);
            //string hash = sha.GenerateSHA256Hash(signup.Password, salt);
            //signup.Password = hash;
            //signup.Salt = salt;
            Random random = new Random();
            signup.OTP = random.Next(10000, 99999).ToString();
            signup.CreationDate = System.DateTime.Now;
            await AddAsync(signup);
        }
        public async Task<Login> CheckUserPassword(string inputPassword, string userName)
        {
            Hash256 sha = new Hash256();
            Login dbResults = await GetByUsername(userName);
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
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.PhoneNumber == number);
            if (results == null)
                return false;
            return true;
        }

        public async Task<bool> CheckLoginEmailExists(string email)
        {
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.Email == email);
            if (results == null)
                return false;
            return true;
        }
        public async Task<bool> CheckLoginUsernameExists(string username)
        {
            var results = await _context.Logins.FirstOrDefaultAsync(n => n.UserName == username);
            if (results == null)
                return false;
            return true;
        }
    }
}
