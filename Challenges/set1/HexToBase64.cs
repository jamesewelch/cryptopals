using System;

namespace Cryptopals.Challenges
{
    public class HexToBase64 : IEncryptionChallenge
    {
        /// <summary>
        /// Convert hex to base64
        /// </summary>
        /// <param name="clearText">hex string</param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            var bytes = new byte[clearText.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(clearText.Substring(i * 2, 2), 16);
            }

            string cipherText = System.Convert.ToBase64String(bytes);
            return cipherText;
        }

        public string Encrypt(string clearText, string key)
        {
            throw new NotImplementedException();
        }
    }
}