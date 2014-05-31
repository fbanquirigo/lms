using System;

namespace SaG.Business.Models
{

    public class OperAudit : BaseEntity
    {
        public int AuditId { get; set; }
        public string OperatorName { get; set; }
        public DateTime? AuditDateTime { get; set; }
        public string ChangeType { get; set; }
        public string SubjectId { get; set; }
        public string FunctionKey { get; set; }
        public string FunctionId { get; set; }
        public string LocationId { get; set; }
        public Operator Operator { get; set; }
        public APIClient APIClient { get; set; }
    }
}