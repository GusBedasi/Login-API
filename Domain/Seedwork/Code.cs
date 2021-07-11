using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Seedwork
{
    public static class Code
    {
        private static Random _random = new Random();
        private static readonly string _lowerCaseCharacters = "abcdefghijklmnopqrstuvxwyz";
        private static readonly string _upperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
        private static readonly string _digits = "0123456789";

        public static string Create(string prefix = null)
        {
            var alphateb = string.Concat(_lowerCaseCharacters, _upperCaseCharacters, _digits);

            var salt = Guid.NewGuid().ToString();

            var bytesToHash = Encoding.UTF8.GetBytes(alphateb + salt);

            var numbers = Enumerable.Range(0, 3).Select(r => _random.Next(100)).ToList();

            var crypt = new SHA256Managed();
            var computeHash = crypt.ComputeHash(bytesToHash);

            var hash = string.Empty;

            hash = computeHash.Aggregate(hash, (result, hashByte) => result + hashByte.ToString("x2"));

            return string.Concat(prefix, hash)[..16];
        }
    }
}