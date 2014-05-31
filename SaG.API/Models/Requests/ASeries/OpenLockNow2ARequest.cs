using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.ASeries
{
    public class OpenLockNow2ARequest : RequestBase, IOpenLockARequest
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