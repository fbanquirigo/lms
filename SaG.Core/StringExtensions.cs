namespace SaG.Core
{
    public static class StringExtensions
    {
        public static string Mid(this string s, int start, int length)
        {
            if (start > s.Length || start < 0)
                return s;

            if (start + length > s.Length)
                length = s.Length - start;

            string ret = s.Substring(start, length);
            return ret;
        }
    }
}
