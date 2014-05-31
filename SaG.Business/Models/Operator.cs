using SaG.Core.Security;

namespace SaG.Business.Models
{
    public class Operator : BaseEntity, ISystemUser
    {
        public int AccessorId { get; set; }
        public Accessor Accessor { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PriorityLevel { get; set; }
        public string LocationId { get; set; }
    }
}
