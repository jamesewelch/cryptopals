namespace Cryptopals
{
    interface IEncryptionChallenge
    {
        string Encrypt(string clearText);

        string Encrypt(string clearText, string key);
    }
}