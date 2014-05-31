using SaG.Business.Models;
using SaG.Services.Contracts;
using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class SealVerifier : ISealVerifier
    {
        private readonly ISealService sealService;

        public SealVerifier(ISealService sealService)
        {
            this.sealService = sealService;
        }

        public bool Verify(string operationResult, out Seal sealResults)
        {
            sealResults = this.sealService.GetSeal(operationResult, SealType.A);
            return true;
        }
    }
}