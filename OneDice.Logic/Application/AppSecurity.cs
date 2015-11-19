using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Logic
{
    public class AppSecurity
    {
        public static string SHA1Encrypt(string data)
        {
            return Encoding.ASCII.GetString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(data)));
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        public static byte[] StringToBytes(string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
