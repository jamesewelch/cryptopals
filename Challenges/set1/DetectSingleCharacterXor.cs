using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Cryptopals.Challenges
{
    /// <summary>
    /// Cryptopal Crypto Challenge Set 1, Challenge 4
    /// One of the 60-character strings in this file has been encrypted by single-character XOR.
    /// Find the key, decrypt the message. 
    /// http://cryptopals.com/sets/1/challenges/4
    /// </summary>
    public class DetectSingleCharacterXor
    {

        public static string Decrypt(string inputFile, out string key)
        {

            if (File.Exists(inputFile) == false)
            {
                throw new FileNotFoundException();
            }

            key = "";
            int bestScore = 0;
            string bestText = string.Empty;

            // read each line of the text file
            using (var reader = File.OpenText(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                { 
                    int score;
                    string output = SingleByteXorCipher.Decrypt(line, out key, out score);
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestText = output;
                        System.Diagnostics.Debug.WriteLine(output);
                    }
                }
            }

            // now let's get best of the best
            return bestText;
        }
    }
}