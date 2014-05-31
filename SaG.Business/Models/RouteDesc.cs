using System;

namespace SaG.Business.Models
{
    public class RouteDesc : BaseEntity
    {
        public int RouteEntity { get; set; }
        public string RouteId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string LocationId { get; set; }
    }
}
