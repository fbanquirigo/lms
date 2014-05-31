using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NHibernate.Linq;
using SaG.Business.Models;
using SaG.Business.Models.Views;
using SaG.Data.Repositories.ReadOnly;

namespace SaG.Data.NHibernate.Repositories.ReadOnly
{
    public class OperationCodeViewRepository : BaseRepository<OperationCode>, IOperationCodeViewRepository
    {
        public OperationCodeViewRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        public OperationCodeDetailView GetActiveOperationCodes(int accessorId, string locationId)
        {
            var code = from opCodes in Session.Query<OperationCode>()
                       join atm in Session.Query<Atm>() on opCodes.Atm.AtmId equals atm.AtmId
                       join locks in Session.Query<Lock>() on atm.Lock.LockEntity equals locks.LockEntity
                       where opCodes.OpCodeRecipient.AccessorId == accessorId && opCodes.DateClosed == null
                       && opCodes.Code != 0
                       select new OperationCodeDetailView() { operationCode = opCodes, atm = atm, locks = locks};

            if (locationId.Equals("999999", System.StringComparison.InvariantCultureIgnoreCase))
                code = code.Where(x => x.operationCode.LocationId == string.Concat("N"+locationId+")"));
            return code.FirstOrDefault();
        }

    }
}
