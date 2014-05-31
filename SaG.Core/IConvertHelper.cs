namespace SaG.Core
{
    public interface IConvertHelper
    {
        int ToInt32(string value);

        int ToInt32(string value, int fromBase);
    }
}