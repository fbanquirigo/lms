using System;

namespace SaG.Core
{
    public class ConvertHelper : IConvertHelper
    {
        public int ToInt32(string value)
        {
            return Convert.ToInt32(value);
        }

        public int ToInt32(string value, int fromBase)
        {
            return Convert.ToInt32(value, fromBase);
        }
    }
}
