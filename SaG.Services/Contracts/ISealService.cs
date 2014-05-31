using SaG.Business.Models;

namespace SaG.Services.Contracts
{
    public interface ISealService
    {
        Seal GetSeal(string operationResult, SealType sealType);
    }
}