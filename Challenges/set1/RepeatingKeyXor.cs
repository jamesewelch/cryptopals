using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Cryptopals.Challenges
{
    /// <summary>
    /// Cryptopal Crypto Challenge Set 1, Challenge 5
    /// Implement repeating-key XOR
    /// http://cryptopals.com/sets/1/challenges/5
    /// </summary>
    public class RepeatingKeyXor
    {
        /// <summary>
        /// Implement repeating-key XOR
        /// Figure out the key
        /// </summary>
        /// <param name="clearText">The provided hex string</param> 
        /// <param name="key">The decryption key</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string key)
        {     
            // convert plan text string to bytes
            var bytesA = Encoding.Default.GetBytes(plainText); 
            var bytesB = Encoding.Default.GetBytes(key); 
           
            // output
            var bytesResponse = new byte[bytesA.Length];

            // loop through inputs, do work, combine into output
            for (int i = 0; i < bytesA.Length; i++)
            {
                // convert char to int
                int int1 = (int)bytesA[i];
                int int2 = (int)bytesB[i % bytesB.Length]; // this part makes it UNfixed! repeatable

                // do XOR
                int int3 = int1 ^ int2;

                // int back to byte 
                bytesResponse[i] = (byte)int3;
            }

            // let's send back hex string
            string hexStringResponse = BitConverter.ToString(bytesResponse).Replace("-", "").Trim();

            return hexStringResponse;
        }
    }
}