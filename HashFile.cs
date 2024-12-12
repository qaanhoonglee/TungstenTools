using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;

namespace FindFile
{
    internal class HashFile
    {
        public static string MD5(string path)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        public static string SHA1(string path)
        {
            using (var cryptoProvider = new SHA1CryptoServiceProvider())
            {
                var stream = File.OpenRead(path);
                string hash = BitConverter
                    .ToString(cryptoProvider.ComputeHash(stream)).Replace("-", "");
                return hash.ToLower();
            }
        }

        public static string SHA256(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}
