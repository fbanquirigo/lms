using SaG.Business;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories;
using SaG.Data.Repositories.ReadOnly;
using SaG.Services.Contracts.Verifiers;

namespace SaG.Services.Verifiers
{
    public class OperationCodeVerifier : IOperationCodeVerifier
    {
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly IOperationCodeViewRepository operationCodeViewRepository;

        public OperationCodeVerifier(IOperationCodeRepository operationCodeRepository, 
            IOperationCodeViewRepository operationCodeViewRepository)
        {
            this.operationCodeRepository = operationCodeRepository;
            this.operationCodeViewRepository = operationCodeViewRepository;
        }

        public bool Verify(int opCode, int atmEntity, out OperationCode operationCode)
        {
            OperationCode result = this.operationCodeRepository.GetOpenOperationCode(opCode, atmEntity);
            operationCode = result;
            return result != null;
        }   

        public bool VerifySealA(int accessorId, string locationId, out OperationCodeDetailView operationCode)
        {
            operationCode = this.operationCodeViewRepository.GetActiveOperationCodes(accessorId, locationId);
            return operationCode != null;
        }

        public bool VerifyClose(OperationCode operationCode, UserType userType)
        {
            switch (userType)
            {
                case UserType.User:
                    return operationCode.UserType == "U";
                case UserType.Manager:
                    return operationCode.UserType == "M";
                default:
                    return false;
            }
        }
    }
}
