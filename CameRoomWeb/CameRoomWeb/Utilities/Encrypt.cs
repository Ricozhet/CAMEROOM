using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CameRoomWeb.Utilities
{
    public class Encrypt
    {
        public string ComputeHash(string plainText, string saltKey)
        {
            byte[] saltBytes = null, plainTextBytes = null, plainTextWithSaltBytes = null, hashBytes = null, hashWithSaltBytes = null;
            string hashValue = "";
            HashAlgorithm algorithm = null;

            try
            {
                saltBytes = Convert.FromBase64String(saltKey);

                // Convert plain text into a byte array.
                plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                // Allocate array, which will hold plain text and salt.
                plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

                // Copy plain text bytes into resulting array.
                for (int i = 0; i < plainTextBytes.Length; i++)
                    plainTextWithSaltBytes[i] = plainTextBytes[i];

                // Append salt bytes to the resulting array.        
                for (int i = 0; i < saltBytes.Length; i++)
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

                // Compute hash value of our plain text with appended salt.        
                algorithm = new SHA1Managed();
                hashBytes = algorithm.ComputeHash(plainTextWithSaltBytes);

                // Create array which will hold hash and original salt bytes.        
                hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

                // Copy hash bytes into resulting array.        
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSaltBytes[i] = hashBytes[i];

                // Append salt bytes to the result.        
                for (int i = 0; i < saltBytes.Length; i++)
                    hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

                // Convert result into a base64-encoded string.        
                hashValue = Convert.ToBase64String(hashWithSaltBytes);
            }
            catch
            {
                throw;
            }
            finally
            {
                saltBytes = null;
                plainTextBytes = null;
                plainTextWithSaltBytes = null;
                hashBytes = null;
                hashWithSaltBytes = null;
            }

            return hashValue;
        }
        public string GetNewSaltKey()
        {
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;
            byte[] saltBytes = null;
            string saltkey = "";

            try
            {
                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);

                saltkey = ConvertSaltKey(saltBytes);
            }
            catch
            {
                throw;
            }

            return saltkey;
        }
        public string ConvertSaltKey(byte[] saltBytes)
        {
            string base64SaltKey = "";

            try
            {
                base64SaltKey = Convert.ToBase64String(saltBytes);
            }
            catch
            {
                throw;
            }

            return base64SaltKey;
        }
    }
}