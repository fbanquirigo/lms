using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models
{
    public class OAuthLoginClient
    {
        public string ClientId { get; set; }

        public string CallbackUri { get; set; }
        
        public string State { get; set; }

        [Required(ErrorMessage = "Enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        public string Password { get; set; }
    }
}