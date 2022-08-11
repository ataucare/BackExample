using Konscious.Security.Cryptography;
using System.Text;

namespace Api.Core.Utilities
{
    public class Security
    {
        private static readonly string Salt = "PR2753692736517484311782577630549130729";

        public static byte[] HashPassword(string password, string salt = null)
        {
            if (salt == null)
            {
                salt = Salt;
            }

            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password))
            {
                Salt = Encoding.UTF8.GetBytes(salt),
                DegreeOfParallelism = 8, // four cores
                Iterations = 4,
                MemorySize = 8192 // KBs
            };

            return argon2.GetBytes(128);
        }

        public static string PasswordToBase64(string password, string salt = null)
        {
            var bytesPassword = Security.HashPassword(password, salt);

            return Convert.ToBase64String(bytesPassword);
        }
    }
}
