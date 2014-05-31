namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Response message header
    /// </summary>
    public class ResponseHeader
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public ResponseStatus StatusCode { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Error id
        /// </summary>
        public string ErrorId { get; set; }
    }
}