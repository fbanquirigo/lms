using System;

namespace SaG.Business.Models
{
    public class ErrorLog : IdentifiableEntity
    {
        public string ErrorId { get; set; }
        public DateTime DateOccured { get; set; }
        public string ConsumerKey { get; set; }
        public string User { get; set; }
        public string Request { get; set; }
        public string Exception { get; set; }
    }
}
