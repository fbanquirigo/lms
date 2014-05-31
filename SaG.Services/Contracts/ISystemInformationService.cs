namespace SaG.Services.Contracts
{
    public interface ISystemInformationService
    {
        string GetSystemVersion();

        string GetProductName();
    }
}