using System.Security.Cryptography;
using System.Text;

namespace ExpressBot.Core.Utilities
{
    public static class SignatureHelper
    {
        public static string CreateHmacSha256Signature(string data, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
