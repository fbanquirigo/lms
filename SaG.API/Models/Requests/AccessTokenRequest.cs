using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests
{
    /// <summary>
    /// Access token request
    /// </summary>
    public class AccessTokenRequest : RequestBase
    {
        /// <summary>
        /// API client consumer id
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// API client consumer secret
        /// </summary>
        [Required]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Authorization code
        /// </summary>
        [Required]
        public string AuthCode { get; set; }
    }
}