using System;

namespace SaG.Business.Models {
    
    public class DispAtm : BaseEntity {
        public int Id { get; set; }
        public Atm Atm { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public string KeyDispatcher0 { get; set; }
        public string KeyDispatcher1 { get; set; }
        public int AtmType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ToRemove { get; set; }
    }
}
