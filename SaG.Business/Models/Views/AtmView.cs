using SaG.Business.Values;

namespace SaG.Business.Models.Views
{
    public class AtmView
    {
        public string AtmId { get; set; }
        public int AtmEntity { get; set; }
        public int AtmType { get; set; }
        public bool DaylightSavingsObserved { get; set; }
        public int LockEntity { get; set; }
        public string LockId { get; set; }
        public int DispEntity { get; set; }
        public string KeyDispatcher0 { get; set; }
        public string KeyDispatcher1 { get; set; }
        public AtmDateRange AtmDateRange { get; set; }
    }
}
