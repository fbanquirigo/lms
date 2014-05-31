namespace SaG.API.Models.Responses
{
    /// <summary>
    /// System information response message.
    /// </summary>
    public class SystemInfoResponse : IResponseWithHeader<ResponseHeader>,
        IResponseWithBody<SystemInfoResponseBody>
    {
        /// <summary>
        /// System information response message header.
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// System information response message body.
        /// </summary>
        public SystemInfoResponseBody Body { get; set; }
    }

    /// <summary>
    /// System information response message body.
    /// </summary>
    public class SystemInfoResponseBody
    {
        /// <summary>
        /// System version
        /// </summary>
        public string SystemVersion { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }
    }
}