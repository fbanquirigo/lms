using System;

namespace SaG.Business.Models {
    
    public class Atm : BaseEntity {
        public int AtmEntity { get; set; }
        public Owner Owner { get; set; }
        public Lock Lock { get; set; }
        public string AtmId { get; set; }
        public string TermSerialNo { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteNo { get; set; }
        public string PhoneNo { get; set; }
        public string MfgModel { get; set; }
        public string ContactName { get; set; }
        public string TypeService { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public int? TimeOffset { get; set; }
        public bool Status { get; set; }
        public bool DaylightSavingsObserved { get; set; }
        public string PrevAtmid { get; set; }
        public DateTime? AtmidChgDate { get; set; }
        public string LocationId { get; set; }
        public int AtmTimeZone { get; set; }
    }
}
