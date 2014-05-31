using System;
using System.Collections.Generic;
using SaG.Business.Models;

namespace SaG.Data.Repositories
{
    public interface IOperationCodeRepository : IRepository<OperationCode>
    {
        bool OpCodeExists(int opCode);

        IEnumerable<OperationCode> GetOperationCodes(int atmEntity, int cmdId, string employeeId);

        IEnumerable<OperationCode> GetOperationCodes(int atmEntity, int cmdId, string employeeId, DateTime fromDate);

        OperationCode GetOpenOperationCode(int operationCode, int atmEntity);

        OperationCode GetOperationCode(int operationCode);

        bool ExecuteArchiveClosedOperationCodes();
    }
}