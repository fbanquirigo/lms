namespace SaG.Business.Models
{

    public class TampResetStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
