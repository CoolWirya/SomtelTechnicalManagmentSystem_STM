using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
namespace SomtelTechnicalManagmentSystem_STM.Data.Security
{
    public class Hash256
    {
        public string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sha256HashingString = new SHA256Managed();
            byte[] hash = sha256HashingString.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);

            }
            return hex.ToString();
        }

        public string GetSHA256Hash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            SHA256Managed sha256HashingString = new SHA256Managed();
            byte[] hash = sha256HashingString.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }
    }
}
