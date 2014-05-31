using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Utils;
using SaG.Business.Models;
using SaG.Data.Repositories;

namespace SaG.Data.NHibernate.Repositories
{
    public class OperationCodeRepository : Repository<OperationCode>, IOperationCodeRepository
    {
        public OperationCodeRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {   
        }

        public bool OpCodeExists(int opCode)
        {
            return Query.Any(x => x.Code == opCode);
        }     

        public IEnumerable<OperationCode> GetOperationCodes(int atmEntity, int cmdId, string employeeId)
        {
            return Query.Where(x => x.Atm.AtmEntity == atmEntity && x.Cmd.CmdId == cmdId
                                    && x.UserEmployeeId == employeeId).ToList();
        }

        public IEnumerable<OperationCode> GetOperationCodes(int atmEntity, int cmdId, string employeeId, DateTime fromDate)
        {
            return Query.Where(x => x.Atm.AtmEntity == atmEntity && x.Cmd.CmdId == cmdId
                                    && x.UserEmployeeId == employeeId && x.StartDateTime >= fromDate).ToList();
        }      

        public OperationCode GetOpenOperationCode(int operationCode, int atmEntity)
        {
            return Query.SingleOrDefault(x => x.Atm.AtmEntity == atmEntity 
                && x.Code == operationCode
                && x.DateClosed == null
                && (x.Cmd.CmdId == 8388608 || x.Cmd.CmdId == 16 || x.Cmd.CmdId == 8));
        }


        public OperationCode GetOperationCode(int operationCode)
        {
            return Query.SingleOrDefault(x => x.Code == operationCode);
        }


        public bool ExecuteArchiveClosedOperationCodes()
        {
            return true;
        }
    }
}
