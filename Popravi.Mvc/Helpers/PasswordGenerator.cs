using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Popravi.Mvc.Helpers
{
    public static class PasswordGenerator
    {
        public static string Make(string unhashedPassword)
        {
            var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(unhashedPassword));
            var hashedPassword = BitConverter.ToString(result).Replace("-", "").ToLower();

            return hashedPassword;
        }
    }
}
