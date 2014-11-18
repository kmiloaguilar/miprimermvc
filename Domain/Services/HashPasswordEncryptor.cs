using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Services
{
    public class HashPasswordEncryptor : IPasswordEncryptor
    {
        #region IPasswordEncryptor Members

        public string Encrypt(string clearTextPassword)
        {
            var encryptedPassword = HashPassword(clearTextPassword);
            var base64String = Convert.ToBase64String(encryptedPassword);
            return base64String;
        }

        #endregion

        public static byte[] HashPassword(string password)
        {
            var provider = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            return provider.ComputeHash(encoding.GetBytes(password));
        }
    }
}