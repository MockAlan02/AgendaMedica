using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Core.Application.Helpers
{
    public class PasswordEncryptations
    {
        public static string ComputeSha256Hash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringbuilder = new();
            //Covert byte array to string
            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i].ToString("X2"));
            }
            return stringbuilder.ToString();



        }
    }
}
