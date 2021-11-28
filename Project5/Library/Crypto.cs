using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Library
{
    public class Crypto
    {
        public static string Encrypt(string plainText)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(plainText);
                byte[] hashBytes = mySHA256.ComputeHash(bytes);
                return Encoding.ASCII.GetString(hashBytes);
            }
        }
        public static string Decrypt(string privateKey, string encryptedText)
        {
            byte[] testData = Encoding.UTF8.GetBytes(encryptedText);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    string base64Encrypted = encryptedText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    byte[] resultBytes = Convert.FromBase64String(base64Encrypted);
                    byte[] decryptedBytes = rsa.Decrypt(resultBytes, true);
                    string decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public static Dictionary<string, string> GenerateKey()
        {
            Dictionary<string, string> PublicPrivateKey = new Dictionary<string, string>();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            PublicPrivateKey.Add("PublicKey", rsa.ToXmlString(false));
            PublicPrivateKey.Add("PrivateKey", rsa.ToXmlString(true));

            return PublicPrivateKey;
        }

    }
}
