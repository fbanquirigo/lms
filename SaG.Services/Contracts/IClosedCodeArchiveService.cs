namespace SaG.Services.Contracts
{
    public interface IClosedCodeArchiveService
    {
        bool Archive(int operationCode);

        bool ArchiveAllClosedOperationCodes();
    }
}