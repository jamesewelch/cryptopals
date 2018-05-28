using System;
using System.Text;

namespace Cryptopals.Challenges
{
    /// <summary>
    /// Cryptopal Crypto Challenge Set 1, Challenge 2
    /// Write a function that takes two equal-length buffers and produces their XOR combination.
    /// http://cryptopals.com/sets/1/challenges/2
    /// </summary>
    public class FixedXor
    {
        /// <summary>
        /// Encrypts two hexstrings
        /// Takes two equal-length buffers and produces their XOR combination 
        /// </summary>
        /// <param name="clearText">String A</param>
        /// <param name="key">String B</param>
        /// <returns></returns>
        public static string Encrypt(string hexStringA, string hexStringB)
        {
            // could do 1 loop, but 
            // hex decode string a
            var bytesA = new byte[hexStringA.Length / 2];
            for (var i = 0; i < bytesA.Length; i++)
            {
                bytesA[i] = Convert.ToByte(hexStringA.Substring(i * 2, 2), 16);
            }

            // hex decode string b
            var bytesB = new byte[hexStringB.Length / 2];
            for (var i = 0; i < bytesB.Length; i++)
            {
                bytesB[i] = Convert.ToByte(hexStringB.Substring(i * 2, 2), 16);
            }

            // output
            var bytesResponse = new byte[hexStringA.Length / 2];

            // loop through inputs, do work, combine into output
            for (int i = 0; i < bytesA.Length; i++)
            {
                // convert char to int
                int int1 = (int)bytesA[i];
                int int2 = (int)bytesB[i % bytesB.Length];

                // do XOR
                int int3 = int1 ^ int2;

                // int back to byte 
                bytesResponse[i] = (byte)int3;
            }

            // plain text decrypted!
            string clearText = Encoding.ASCII.GetString(bytesResponse);
            System.Diagnostics.Debug.WriteLine("@" + clearText);

            // let's send back hex string
            string hexStringResponse = BitConverter.ToString(bytesResponse).Replace("-", "").Trim();

            return hexStringResponse;
        }
    }
}