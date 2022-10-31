using System.Security.Cryptography;
using System.Text;

namespace CjApp.Jwt.Helper
{
    public static class Md5Helper
    {
        public static string Md5Encrypt32(string password, bool isUpper = true)
        {
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            var pwd = BitConverter.ToString(bytes).Replace("-", "");
            return isUpper ? pwd.ToUpper() : pwd.ToLower();
        }
    }
}