using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.BSeries
{
    /// <summary>
    /// Open lock now (1B) request message.
    /// </summary>
    public class OpenLockNow1BRequest : RequestBase, IOpenLockBRequest
    {
        /// <summary>
        /// Lock id
        /// </summary>
        [Required]
        public string LockId { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        [Required]
        public string UserId { get; set; }
    }
}