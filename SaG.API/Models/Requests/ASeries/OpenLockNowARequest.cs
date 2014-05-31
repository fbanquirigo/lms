using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.ASeries
{
    /// <summary>
    /// Open lock now (A) request message.
    /// </summary>
    public class OpenLockNowARequest : RequestBase, IOpenLockARequest
    {
        /// <summary>
        /// Atm id
        /// </summary>
        [Required]
        public string AtmId { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        [Required]
        public string UserId { get; set; }
    }
}