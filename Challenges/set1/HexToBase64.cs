using System;

namespace Cryptopals.Challenges
{
    /// <summary>
    /// Cryptopal Crypto Challenge Set 1, Challenge 1
    /// Convert hex to base64
    /// http://cryptopals.com/sets/1/challenges/1
    /// </summary>
    public class HexToBase64
    {
        /// <summary>
        /// Convert hex to base64
        /// </summary>
        /// <param name="hexString">hex string</param>
        /// <returns></returns>
        public static string Encrypt(string hexString)
        {
            // convert the hex string to bytes
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            // convert the bytes to base64
            string cipherText = System.Convert.ToBase64String(bytes);

            return cipherText;
        }

    }
}