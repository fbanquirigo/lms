namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Access token response message
    /// </summary>
    public class AccessTokenResponse : IResponseWithHeader<ResponseHeader>,
        IResponseWithBody<AccessTokenResponseBody>
    {
        /// <summary>
        /// Access token response message header.
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Access token response message body.
        /// </summary>
        public AccessTokenResponseBody Body { get; set; }
    }

    /// <summary>
    /// Access token response message body.
    /// </summary>
    public class AccessTokenResponseBody
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}