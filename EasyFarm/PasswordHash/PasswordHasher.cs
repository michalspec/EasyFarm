using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EasyFarm.PasswordHash
{
    public static class PasswordHasher
    { 
        private const int saltSize = 16;
        private const int keySize = 32;
        private const int Iterations = 10000;
      
        public static (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if(parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. " +
                    "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != Iterations;

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256);

            var keyToCheck = algorithm.GetBytes(keySize);

            var verified = keyToCheck.SequenceEqual(key);

            return (verified, needsUpgrade);
        }

        public static string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password,
                saltSize,
                Iterations,
                HashAlgorithmName.SHA256);
            
            var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
            var salt = Convert.ToBase64String(algorithm.Salt);
            return $"{Iterations}.{salt}.{key}";
            
        }
    }
}
