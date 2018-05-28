using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryptopals.Challenges;

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
            HexToBase64 challenge = new HexToBase64();
            string actual = challenge.Encrypt(input);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
