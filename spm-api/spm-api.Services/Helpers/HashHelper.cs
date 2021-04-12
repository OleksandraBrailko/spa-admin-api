using System.Security.Cryptography;
using System.Text;

namespace spm_api.Services.Helpers
{
    public static class HashHelper
    {
        public static string GetSha256Hash(string text)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
