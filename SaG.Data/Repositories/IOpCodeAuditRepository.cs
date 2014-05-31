using System;
using System.Collections.Generic;
using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IOpCodeAuditRepository : IRepository<OpCodeAudit>
    {
        IEnumerable<OpCodeAudit> GetOpCodeAudits(int atmId, string cmdDesc, string userEmployeeId);

        IEnumerable<OpCodeAudit> GetOpCodeAudits(int atmId, string cmdDesc, string userEmployeeId, DateTime fromDate);
    }
}