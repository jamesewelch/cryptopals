using System;
using System.Text;

namespace Cryptopals.Challenges
{
    public class FixedXOR : IEncryptionChallenge
    {
        /// <summary>
        /// Not Implemented 
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encrypts two hexstrings
        /// Takes two equal-length buffers and produces their XOR combination 
        /// </summary>
        /// <param name="clearText">String A</param>
        /// <param name="key">String B</param>
        /// <returns></returns>
        public string Encrypt(string clearText, string key)
        {
            // equal length strings, so don't need to mod
            if (clearText.Length != key.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            // hex decode string a
            var input1 = new byte[clearText.Length / 2];
            for (var i = 0; i < input1.Length; i++)
            {
                input1[i] = Convert.ToByte(clearText.Substring(i * 2, 2), 16);
            }

            // hex decode string b
            var input2 = new byte[key.Length / 2];
            for (var i = 0; i < input2.Length; i++)
            {
                input2[i] = Convert.ToByte(key.Substring(i * 2, 2), 16);
            }

            // output
            var output = new byte[clearText.Length / 2];

            // loop through inputs, do work, combine into output
            for (int i = 0; i < input1.Length; i++)
            {
                // convert char to int
                int int1 = (int)input1[i];
                int int2 = (int)input2[i];

                // do XOR
                int int3 = int1 ^ int2;

                // int back to byte 
                output[i] = (byte)int3;
            }

            // plain text decrypted!
            string cipherText = Encoding.ASCII.GetString(output);

            // let's send back hex string
            string hexText = BitConverter.ToString(output).Replace("-", "").Trim();

            return hexText;
        }
    }
}