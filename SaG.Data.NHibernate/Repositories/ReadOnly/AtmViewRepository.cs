using System.Linq;
using NHibernate.Linq;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Business.Values;
using SaG.Data.Repositories.ReadOnly;

namespace SaG.Data.NHibernate.Repositories.ReadOnly
{
    public class AtmViewRepository : BaseRepository<AtmView>, IAtmViewRepository
    {
        public AtmViewRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {  
        }

        public AtmView GetAssignedAtm(string atmId)
        {
            return AtmView.FirstOrDefault(
                x => x.AtmId == atmId && x.LockId != "(unassigned)" && x.AtmType != 2); 
        }

        public AtmView GetAssignedAtmByLockId(string lockId)
        {
            return AtmView.FirstOrDefault(x => x.LockId == lockId && x.AtmType != 2);
        }

        private IQueryable<AtmView> AtmView
        {
            get
            {
                return from atm in Session.Query<Atm>()
                       join locks in Session.Query<Lock>() on atm.Lock equals locks
                       join dispAtm in Session.Query<DispAtm>() on atm equals dispAtm.Atm
                       select new AtmView
                              {
                                  AtmId = atm.AtmId,
                                  AtmEntity = atm.AtmEntity,
                                  DaylightSavingsObserved = atm.DaylightSavingsObserved,
                                  LockEntity = locks.LockEntity,
                                  LockId = locks.LockId,
                                  DispEntity = dispAtm.Dispatcher.DispEntity,
                                  AtmType = dispAtm.AtmType,
                                  KeyDispatcher0 = dispAtm.KeyDispatcher0,
                                  KeyDispatcher1 = dispAtm.KeyDispatcher1,
                                  AtmDateRange = new AtmDateRange
                                    {
                                        StartDate = dispAtm.StartDate, 
                                        EndDate = dispAtm.EndDate
                                    }
                              };
            }
        }
    }
}
