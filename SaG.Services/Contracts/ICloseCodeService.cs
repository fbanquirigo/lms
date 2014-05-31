namespace SaG.Services.Contracts
{
    public interface ICloseCodeService
    {
        bool CloseCodeA(int opCode, string atmId, string operationResult);

        bool CloseCodeViaSealA(string userId, string operationResult);
    }
}