namespace SaG.Core
{
    public interface IRandomGenerator
    {
        string String(int length, string allowedCharacters);
    }
}