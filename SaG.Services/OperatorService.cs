using SaG.Business.Models;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class OperatorService : IOperatorService
    {
        private readonly ILockCryptoService crypto;
        private readonly IOperatorRepository operatorRepository;

        public OperatorService(IOperatorRepository operatorRepository, ILockCryptoService crypto)
        {
            this.operatorRepository = operatorRepository;
            this.crypto = crypto;
        }

        public bool ValidOperatorLogin(string username, string password)
        {
            Operator user = this.operatorRepository.GetOperator(username);
            if (user == null)
                return false;

            string decryptedPassword = this.crypto.DecryptDBValue(user.Password, CryptoType.Password);
            return decryptedPassword == password;
        }     

        public Operator GetOperator(string username)
        {
            return this.operatorRepository.GetOperator(username);
        }
    }   
   
}
