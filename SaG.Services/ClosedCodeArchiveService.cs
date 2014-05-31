using System;
using SaG.Business.Models;
using SaG.Data;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class ClosedCodeArchiveService : IClosedCodeArchiveService
    {
        private readonly IOperationCodeRepository operationCodeRepository;
        private readonly IRepository<OpCodeAudit> opCodeAuditRepository;
        private readonly ISystemContext systemContext;

        public ClosedCodeArchiveService(IOperationCodeRepository operationCodeRepository,
            IRepository<OpCodeAudit> opCodeAuditRepository, ISystemContext systemContext)
        {
            this.operationCodeRepository = operationCodeRepository;
            this.opCodeAuditRepository = opCodeAuditRepository;
            this.systemContext = systemContext;
        }   

        public bool Archive(int operationCode)
        {
            OperationCode code = this.operationCodeRepository.GetOperationCode(operationCode);
            if (code == null)
                throw new ArgumentException(string.Format("Operation Code: {0} does not exist.", operationCode));

            if (code.DateClosed == null)
                return false;

            var opCodeAudit = new OpCodeAudit
            {
                StartDtTime = code.StartDateTime,
                EndDtTime = code.EndDateTime,
                AtmId = code.Atm.AtmId,
                CmdDesc = code.Cmd.Description,
                RouteId = code.RouteDesc.RouteId,
                TouchKeyId = code.TouchKey.TouchKeyId,
                LinkDispId = code.LinkDispId,
                UserEmployeeId = code.UserEmployeeId,
                UserType = code.UserType,
                OperCode = code.Code.ToString(),
                Duration = code.Duration,
                LockId = code.Atm.Lock.LockId,
                LockResult = code.LockResult,
                SessStartDtTime = code.SessionStart,
                DtTmClosed = code.DateClosed,
                UserName = string.Format("{0} {1}", code.OpCodeRecipient.FirstName, code.OpCodeRecipient.LastName),
                OperName = string.Format("{0} {1}", code.OpCodeCreator.FirstName, code.OpCodeCreator.LastName),
                SiteName = code.Atm.SiteName,
                SiteAddress = code.Atm.SiteAddress,
                LocationId = this.systemContext.LocationId
            };

            this.operationCodeRepository.Delete(code);
            this.opCodeAuditRepository.Save(opCodeAudit);
            return true;
        }  

        public bool ArchiveAllClosedOperationCodes()
        {
            return this.operationCodeRepository.ExecuteArchiveClosedOperationCodes();
        }
    }
}
