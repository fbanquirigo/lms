using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.ASeries
{
    /// <summary>
    /// Close code (A) request message.
    /// </summary>
    public class CloseCodeARequest : RequestBase, ICloseCodeRequest
    {  
        /// <summary>
        /// Atm id
        /// </summary>
        [Required]
        public string AtmId { get; set; }

        /// <summary>
        /// Operation code
        /// </summary>
        [Required]
        public int OperationCode { get; set; }

        /// <summary>
        /// Operation result
        /// </summary>
        [Required]
        public string OperationResult { get; set; }
    }
}