namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Access token expired response message.
    /// </summary>
    public class AccessTokenExpiresResponse : IResponseWithHeader<ResponseHeader>, 
        IResponseWithBody<AccessTokenExpiresResponseBody>
    {
        /// <summary>
        /// Access token expired response message header.
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Access token expired response message body.
        /// </summary>
        public AccessTokenExpiresResponseBody Body { get; set; }
    }

    /// <summary>
    /// Access token expired message body.
    /// </summary>
    public class AccessTokenExpiresResponseBody
    {
        /// <summary>
        /// Determines if the token is expired.
        /// </summary>
        public bool TokenExpired { get; set; }
    }
}