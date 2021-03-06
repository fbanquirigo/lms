﻿using System.ComponentModel.DataAnnotations;

namespace SaG.API.Models.Requests.BSeries
{
    /// <summary>
    /// Open lock (B) request message.
    /// </summary>
    public class OpenLockBRequest : RequestBase, IOpenLockBRequest
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

        /// <summary>
        /// Touch key id
        /// </summary>
        [Required]
        public string TouchKeyId { get; set; }

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

        /// <summary>
        /// Lock status
        /// </summary>
        [Required]
        [Range(0, 9)]
        public int LockStatus { get; set; }
    }
}