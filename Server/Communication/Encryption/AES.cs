using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Communication.Encryption
{
    public static class AES
    {
        private const int keySize = 256; // AES-256
        private const int blockSize = 128; // AES uses 128-bit blocks

        public static string Encrypt(string password, string text)
        {
            byte[] salt = GenerateRandomBytes(blockSize / 8); // Generate a random salt
            byte[] key = GenerateKey(password, salt); // Generate a key based on the password and salt

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.BlockSize = blockSize;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.GenerateIV(); // Generate a random IV

                byte[] encrypted;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] inputBuffer = Encoding.UTF8.GetBytes(text);

                    encrypted = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                }

                byte[] result = new byte[salt.Length + aes.IV.Length + encrypted.Length];

                Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
                Buffer.BlockCopy(aes.IV, 0, result, salt.Length, aes.IV.Length);
                Buffer.BlockCopy(encrypted, 0, result, salt.Length + aes.IV.Length, encrypted.Length);

                return Convert.ToBase64String(result);
            }
        }

        public static string Decrypt(string password, string text)
        {
            byte[] data = Convert.FromBase64String(text);

            byte[] salt = new byte[blockSize / 8];
            byte[] iv = new byte[blockSize / 8];
            byte[] cipherText = new byte[data.Length - salt.Length - iv.Length];

            Buffer.BlockCopy(data, 0, salt, 0, salt.Length);
            Buffer.BlockCopy(data, salt.Length, iv, 0, iv.Length);
            Buffer.BlockCopy(data, salt.Length + iv.Length, cipherText, 0, cipherText.Length);

            byte[] key = GenerateKey(password, salt);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.BlockSize = blockSize;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }

        private static byte[] GenerateRandomBytes(int count)
        {
            byte[] buffer = new byte[count];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            return buffer;
        }

        private static byte[] GenerateKey(string password, byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return pbkdf2.GetBytes(keySize / 8);
            }
        }
    }
}
