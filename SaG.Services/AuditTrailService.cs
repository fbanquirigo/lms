using System;
using SaG.Business;
using SaG.Business.Models;
using SaG.Data;
using SaG.Data.Repositories;
using SaG.Services.Contracts;

namespace SaG.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        private readonly ISystemContext systemContext;
        private readonly IClientContext clientContext;
        private readonly IRepository<OperAudit> operAuditRepository;
        private readonly IAPIClientRepository apiClientRepository;
        private readonly IOperatorRepository operatorRepository;
        private readonly IRepository<Accessor> accessorRepository;

        public AuditTrailService(ISystemContext systemContext,
            IClientContext clientContext,
            IRepository<OperAudit> operAuditRepository,
            IAPIClientRepository apiClientRepository,
            IOperatorRepository operatorRepository,
            IRepository<Accessor> accessorRepository)
        {
            this.systemContext = systemContext;
            this.clientContext = clientContext;
            this.operAuditRepository = operAuditRepository;
            this.apiClientRepository = apiClientRepository;
            this.operatorRepository = operatorRepository;
            this.accessorRepository = accessorRepository;
        }

        public void Audit(AuditType type, string subjectId, string functionKey, string functionId)
        {
            Audit(type, subjectId, functionKey, functionId, this.systemContext.LocationId);
        }

        public void Audit(AuditType type, string subjectId, string functionKey, string functionId, string location)
        {
            APIClient apiClient = this.apiClientRepository.GetApiClient(this.clientContext.Consumer.ConsumerId);
            Operator userOperator = this.operatorRepository.GetById(this.clientContext.Operator.Id);
            Accessor accessor = this.accessorRepository.GetById(userOperator.AccessorId);

            var audit = new OperAudit
            {
                ChangeType = ToChangeType(type),
                SubjectId = subjectId,
                FunctionKey = functionKey,
                FunctionId = functionId,
                AuditDateTime = DateTime.Now,
                OperatorName = string.Format("{0}, {1}", accessor.LastName, accessor.FirstName),
                APIClient = apiClient,
                Operator = userOperator
            };
            SaveAudit(audit);
        }

        public void Audit(AuditType type, string operatorName, string subjectId, string functionKey, string functionId, string location)
        {
            APIClient apiClient = this.apiClientRepository.GetApiClient(this.clientContext.Consumer.ConsumerId);
            Operator userOperator = this.operatorRepository.GetById(this.clientContext.Operator.Id);

            var audit = new OperAudit
            {
                ChangeType = ToChangeType(type),
                SubjectId = subjectId,
                FunctionKey = functionKey,
                FunctionId = functionId,
                AuditDateTime = DateTime.Now,
                OperatorName = operatorName,
                APIClient = apiClient,
                Operator = userOperator
            };
            SaveAudit(audit);
        }

        private void SaveAudit(OperAudit audit)
        {
            this.operAuditRepository.Save(audit);
        }

        private static string ToChangeType(AuditType auditType)
        {
            switch (auditType)
            {
                case AuditType.SignOn:
                    return "Sign-On";
                case AuditType.SignOff:
                    return "Sign-Off";
                default:
                    return auditType.ToString();
            }
        }
    }
}
