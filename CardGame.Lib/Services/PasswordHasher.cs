using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CardGame.Lib.Services
{
    public static class PasswordHasher
    {
        const KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA1;
        const int iterationCount = 1000;
        const int subkeyLength = 256 / 8;
        const int saltSize = 128 / 8;


        public static string HashPassword(string password)
        {
            byte[] salt = new byte[saltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] subkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: prf,
                iterationCount: iterationCount,
                numBytesRequested: subkeyLength);

            var outputBytes = new byte[saltSize + subkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 0, saltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, saltSize, subkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        public static bool ComparePasswords(string hashedPassword, string comparisonPassword)
        {
            byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length != saltSize + subkeyLength)
            {
                return false;
            }

            byte[] salt = new byte[saltSize];
            Buffer.BlockCopy(decodedHashedPassword, 0, salt, 0, salt.Length);

            byte[] expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(comparisonPassword, salt, prf, iterationCount, subkeyLength);

            return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
        }
    }
}
