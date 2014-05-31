namespace SaG.Core
{
    public static class RandomGeneratorExtensions
    {
        public static string AuthCodeString(this IRandomGenerator randomGenerator)
        {
            return AuthCodeString(randomGenerator, 32);
        }

        public static string AuthCodeString(this IRandomGenerator randomGenerator, int length)
        {
            return randomGenerator.String(length, "abcdefghijkmnopqrstuvwxyz1234567890");
        }

        public static string AccessTokenString(this IRandomGenerator randomGenerator)
        {
            return AccessTokenString(randomGenerator, 32);
        }

        public static string AccessTokenString(this IRandomGenerator randomGenerator, int length)
        {
            return randomGenerator.String(length, "abcdefghijkmnopqrstuvwxyz1234567890");
        }
    }
}
