using System;

namespace SaG.Business.Models
{
    public class APIAccessToken : IdentifiableEntity, IExpirable
    {  
        public APIClient Client { get; set; }

        public APIAuthCode AuthCode { get; set; }

        public Operator Operator { get; set; }

        public string AccessToken { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public DateTime? LastUsedOn { get; set; }

        public bool IsExpired { get; set; }
    }
}
