using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.BLL.PasswordHasher.Hasher
{
    public class HashService : IHashService
    {
        public string HashPassword(string password)
        {
            using (SHA256 mySha256 = SHA256.Create())
            {
                byte[] hash = mySha256.ComputeHash(Encoding.UTF8.GetBytes(password.ToString()));

                StringBuilder hashSb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hashSb.Append(hash[i].ToString("x2"));
                }
                return hashSb.ToString();
            }
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }

    
}
