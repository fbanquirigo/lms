using SaG.Business.Models.Views;

namespace SaG.Data.Repositories.ReadOnly
{
    public interface IAtmViewRepository
    {
        AtmView GetAssignedAtm(string atmId);

        AtmView GetAssignedAtmByLockId(string lockId);
    }
}