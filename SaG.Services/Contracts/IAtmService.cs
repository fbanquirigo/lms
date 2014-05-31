using SaG.Business.Models;
using SaG.Business.Models.Views;

namespace SaG.Services.Contracts
{
    public interface IAtmService
    {
        bool VerifyAtm(string atmId, out AtmView atmView);

        bool VerifyAtmLock(string lockId, out AtmView atmView);

        Atm GetAtm(int atmId);
    }
}