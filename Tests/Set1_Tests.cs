using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryptopals.Challenges;
using System.IO;

namespace Cryptopals.Tests
{
    [TestClass]
    public class Set1_Tests
    {
        [TestMethod]
        public void HexToBase64_Test()
        {
            // assign
            string input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

            // execute 
            string actual = HexToBase64.Encrypt(input);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FixedXor_Test()
        {
            // assign
            string input = "1c0111001f010100061a024b53535009181c";
            string key = "686974207468652062756c6c277320657965";
            string expected = "746865206b696420646f6e277420706c6179";

            // execute 
            string actual = FixedXor.Encrypt(input, key);

            // assert, ignore case
            Assert.AreEqual(expected, actual, true);
        }

        [TestMethod]
        public void SingleByteXorCipher_Test()
        {
            // assign
            string input = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
            string key = null;
            string expected = "Cooking MC's like a pound of bacon";

            // execute 
            string actual = SingleByteXorCipher.Decrypt(input, out key);

            // assert, ignore case
            Assert.IsNotNull(actual);
            Assert.IsNotNull(key);
            Assert.AreEqual(expected, actual, true);

            System.Diagnostics.Debug.WriteLine("------------------");
            System.Diagnostics.Debug.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine("------------------");
        }

        [TestMethod]
        public void DetectSingleCharacterXor_Test()
        {
            // assign 
            string input = Path.GetFullPath("data/set1_challenge4.txt");
            string key = null;
            string expected = "Now that the party is jumping\n";

            // execute 
            string actual = DetectSingleCharacterXor.Decrypt(input, out key);

            // assert, ignore case
            Assert.IsNotNull(actual);
            Assert.IsNotNull(key);
            Assert.AreEqual(expected, actual, true);

            System.Diagnostics.Debug.WriteLine("------------------");
            System.Diagnostics.Debug.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine("------------------");
        }

        [TestMethod]
        public void RepeatingKeyXor_Test()
        {
            // assign
            string input  = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";            
            string key = "ICE";
            string expected = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";

            // execute 
            string actual = RepeatingKeyXor.Encrypt(input, key); 

            // assert, ignore case
            Assert.AreEqual(expected, actual, true); 
        }
    }
}
