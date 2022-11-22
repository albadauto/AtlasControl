using System.Security.Cryptography;
using System.Text;

namespace AtlasControl.Helpers
{
    public class CryptographyHelper
    {
        private readonly HashAlgorithm _crypto;
        public CryptographyHelper(HashAlgorithm crypto)
        {
            _crypto = crypto;
        }
        public string hashPassword(string password)
        {
            byte[] pass = Encoding.Default.GetBytes(password);
            var crypto = _crypto.ComputeHash(pass);
            return Convert.ToBase64String(crypto);
        }
    }
}
