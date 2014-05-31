using System;

namespace SaG.Core
{
    public class RandomGenerator : IRandomGenerator
    {
        public string String(int length, string allowedCharacters)
        {
            var chars = new char[length];
            var random = new Random();

            for (var i = 0; i < length; i++)
                chars[i] = allowedCharacters[random.Next(0, allowedCharacters.Length)];
            return new string(chars);
        }
    }
}
