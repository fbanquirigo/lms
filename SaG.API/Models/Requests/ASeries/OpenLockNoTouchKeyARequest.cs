using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.ASeries
{
    /// <summary>
    /// Open lock no touch key (A) request message.
    /// </summary>
    public class OpenLockNoTouchKeyARequest : RequestBase, IOpenLockARequest
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

        /// <summary>
        /// Operation date.  Valid formats ("dd/MM/yyyy", "dd-MM-yyyy", "ddMMyyyy")
        /// </summary>
        [Required]
        public string Date { get; set; }

        /// <summary>
        /// Operation hour
        /// </summary>
        [Required]
        [Range(0, 23)]
        public int Hour { get; set; }

        /// <summary>
        /// Time block.  Valid values (4, 8, 12, 24)
        /// </summary>
        [Required]
        public int TimeBlock { get; set; }
    }
}