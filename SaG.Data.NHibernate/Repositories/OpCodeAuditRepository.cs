using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class OpCodeAuditRepository : Repository<OpCodeAudit>, IOpCodeAuditRepository
    {
        public OpCodeAuditRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        public IEnumerable<OpCodeAudit> GetOpCodeAudits(int atmId, string cmdDesc, string userEmployeeId)
        {
            return Query.Where(x => x.AtmId == atmId.ToString(CultureInfo.InvariantCulture)
                                    && x.CmdDesc == cmdDesc &&
                                    x.UserEmployeeId == userEmployeeId).ToList();
        }

        public IEnumerable<OpCodeAudit> GetOpCodeAudits(int atmId, string cmdDesc, string userEmployeeId, DateTime fromDate)
        {
            return Query.Where(x => x.AtmId == atmId.ToString(CultureInfo.InvariantCulture)
                                    && x.CmdDesc == cmdDesc && x.UserEmployeeId == userEmployeeId
                                    && x.StartDtTime >= fromDate).ToList();
        }
    }
}
