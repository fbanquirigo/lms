using System;    

namespace SaG.Business.Models {
    
    public class Dispatcher : BaseEntity {
        public int DispEntity { get; set; }
        public Owner Owner { get; set; }
        public string DispatchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastExport { get; set; }
        public string DispatcherBlock { get; set; }
        public bool SystemOwner { get; set; }
        public DateTime ExportStartDate { get; set; }
        public DateTime ExportEndDate { get; set; }
    }
}
