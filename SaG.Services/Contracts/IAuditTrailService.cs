namespace SaG.Services.Contracts
{
    public interface IAuditTrailService
    {
        void Audit(AuditType type, string subjectId, string functionKey, string functionId);

        void Audit(AuditType type, string subjectId, string functionKey, string functionId, string location);

        void Audit(AuditType type, string operatorName, string subjectId, string functionKey, string functionId, string location);
    }
}