using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace WebApi.Services
{
    public class Password : IPassword
    {
        public (string Salt, string Hashed) Hash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = HashedValue(salt, password);
            return (Convert.ToBase64String(salt), hashed);
        }

        public bool Valid(string password, string salt, string hashed)
        {
            byte[] saltValid = Convert.FromBase64String(salt);
            string hashedValid = HashedValue(saltValid, password);
            return string.Equals(hashed, hashedValid);
        }

        private string HashedValue(byte[] salt, string password)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                )
            );
        }
    }
}
