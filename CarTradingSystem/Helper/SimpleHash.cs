using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CarTradingSystem
{
    public class SimpleHash
    {
        public static byte[] Hash(HashAlgorithm algorithm, byte[] input)
        {
            return algorithm.ComputeHash(input);
        }

        public static string HexHash(HashAlgorithm algorithm, string text)
        {
            byte[] input = UnicodeEncoding.Unicode.GetBytes(text);
            return string.Concat(Hash(algorithm, input).Select(b => b.ToString("x2")));
        }

        public static string Base64Hash(HashAlgorithm algorithm, string text)
        {
            byte[] input = UnicodeEncoding.Unicode.GetBytes(text);
            return Convert.ToBase64String(Hash(algorithm, input));
        }
    }
}