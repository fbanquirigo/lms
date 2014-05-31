using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.ASeries
{
    /// <summary>
    /// Close code via seal (A) request message.
    /// </summary>
    public class CloseCodeViaSealARequest : RequestBase, ICloseCodeRequest
    {
        /// <summary>
        /// User id
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Operation result
        /// </summary>
        [Required]
        public string OperationResult { get; set; }
    }
}