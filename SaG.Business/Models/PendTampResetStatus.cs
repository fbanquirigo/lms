﻿namespace SaG.Business.Models
{

    public class PendTampResetStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
