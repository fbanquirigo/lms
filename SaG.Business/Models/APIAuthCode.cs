using System;

namespace SaG.Business.Models
{
    public class APIAuthCode : IdentifiableEntity, IExpirable
    {
        public int Id { get; set; }

        public APIClient Client { get; set; }

        public string AuthCode { get; set; }

        public Operator Operator { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public bool Tokenized { get; set; }

        public bool IsExpired { get; set; }
    }
}
