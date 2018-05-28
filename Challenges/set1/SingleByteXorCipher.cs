using System;
using System.Text;

namespace Cryptopals.Challenges
{
    /// <summary>
    /// Cryptopal Crypto Challenge Set 1, Challenge 3
    /// The hex encoded string has been XOR'd against a single character. 
    /// Find the key, decrypt the message. 
    /// http://cryptopals.com/sets/1/challenges/3
    /// </summary>
    public class SingleByteXorCipher
    {
        /// <summary>
        /// Decrypt the hexstring using a single-byte XOR cipher
        /// Figure out the key
        /// </summary>
        /// <param name="hexString">The provided hex string</param> 
        /// <param name="key">The decryption key</param>
        /// <returns></returns>
        public static string Decrypt(string hexStringA, out string key)
        {
            // hex decode string a
            var bytesA = new byte[hexStringA.Length / 2];
            for (var i = 0; i < bytesA.Length; i++)
            {
                bytesA[i] = Convert.ToByte(hexStringA.Substring(i * 2, 2), 16);
            }

            string keys = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var bytesB = new byte[keys.Length];
            for (var i = 0; i < bytesB.Length; i++)
            {
                char keyChar = Convert.ToChar(keys.Substring(i, 1));
                bytesB[i] = Convert.ToByte(keyChar);
            }

            var decryptedStrings = new string[bytesB.Length];

            // base 16, so 16 possible keys
            for (int x = 0; x < keys.Length; x++)
            {
                // output
                var bytesResponse = new byte[hexStringA.Length / 2];
                int intKey = bytesB[x];

                // loop through inputs, do work, combine into output
                for (int i = 0; i < bytesA.Length; i++)
                {
                    // convert char to int
                    int int1 = (int)bytesA[i];

                    // do XOR
                    int int3 = int1 ^ intKey;

                    // int back to byte 
                    bytesResponse[i] = (byte)int3;
                }

                // plain text decrypted!
                string clearText = Encoding.Default.GetString(bytesResponse);
                decryptedStrings[x] = clearText;
                System.Diagnostics.Debug.WriteLine("@" + x + "= " + clearText);
            }

            int bestIndex = FindBestIndex(decryptedStrings);
            string bestScore = decryptedStrings[bestIndex];
            key = keys.Substring(bestIndex, 1);
            return bestScore;
        }

        /// <summary>
        /// Finds the best decrypted string
        /// </summary>
        /// <param name="decryptedStrings"></param>
        /// <param name="bestIndex"></param>
        /// <returns></returns>
        public static int FindBestIndex(string[] decryptedStrings)
        {
            int bestScore = -100;
            string bestString = null;
            int bestIndex = 0;

            for (int i = 0; i < decryptedStrings.Length; i++)
            {
                string decryptedString = decryptedStrings[i];
                int score = LewandScore(decryptedString);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestString = decryptedString;
                    bestIndex = i;
                }
            }
 
            return bestIndex;
        }

        /// <summary>
        /// Scores words based on letter frequency
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Score</returns>
        public static int LewandScore(string input)
        {
            char[] letterRanks = "etaoinshrdlcumwfgypbvkjxqz".ToCharArray();
            int score = 0; 
            input = input.Replace(" ", "").ToLower();

            foreach (char letter in input.ToCharArray())
            {
                bool foundMatch = false;
                for (int i = 0; i < letterRanks.Length; i++)
                {

                    if (letter == letterRanks[i])
                    {
                        foundMatch = true;
                        score += letterRanks.Length - i;
                        break;
                    }
                }

                if (foundMatch == false)
                {
                    score -= 1;
                }
            }

            score = score / input.Length; 
            return score;
        }
    }
}
