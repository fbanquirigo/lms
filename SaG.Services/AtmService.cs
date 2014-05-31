using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories;
using SaG.Data.Repositories.ReadOnly;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class AtmService : IAtmService
    {
        private readonly IAtmViewRepository atmViewRepository;
        private readonly IAtmRepository atmRepository;

        public AtmService(IAtmViewRepository atmViewRepository, IAtmRepository atmRepository)
        {
            this.atmViewRepository = atmViewRepository;
            this.atmRepository = atmRepository;
        }

        public bool VerifyAtm(string atmId, out AtmView atmView)
        {
            atmView = this.atmViewRepository.GetAssignedAtm(atmId);
            return atmView != null;
        }

        public bool VerifyAtmLock(string lockId, out AtmView atmView)
        {
            atmView = this.atmViewRepository.GetAssignedAtmByLockId(lockId);
            return atmView != null;
        }

        public Atm GetAtm(int atmId)
        {
            return this.atmRepository.GetById(atmId);
        }
    }
}
