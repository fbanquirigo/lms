namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Close code response
    /// </summary>
    public class CloseCodeResponse : IResponseWithHeader<ResponseHeader>, IResponseWithBody<CloseCodeResponseBody>
    {
        /// <summary>
        /// Close code response message header.
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Close code response message body.
        /// </summary>
        public CloseCodeResponseBody Body { get; set; }
    }

    /// <summary>
    /// Close code response message body
    /// </summary>
    public class CloseCodeResponseBody
    {
        /// <summary>
        /// Determines if the code was successfully closed.
        /// </summary>
        public bool CodeClosed { get; set; }
    }
}