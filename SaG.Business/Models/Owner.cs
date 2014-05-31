namespace SaG.Business.Models
{
    public class Owner : BaseEntity
    {
        public int OwnerEntity { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; }
        public string PhoneNo { get; set; }
        public bool SystemOwner { get; set; }
        public string MasterKey0 { get; set; }
        public string MasterKey1 { get; set; }
    }
}
