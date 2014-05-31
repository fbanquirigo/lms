namespace SaG.Business.Models
{
    public class APIClient : IdentifiableEntity
    {
        public int Id { get; set; }

        public string ApplicationName { get; set; }

        public string ConsumerKey { get; set; }

        public string ConsumerSecret { get; set; }

        public string Domain { get; set; }

        public bool Suspended { get; set; }
    }
}
