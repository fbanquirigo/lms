namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Operation code response message.
    /// </summary>
    public class OperationCodeResponse : IResponseWithHeader<ResponseHeader>, 
        IResponseWithBody<OperationCodeResponseBody>
    {
        /// <summary>
        /// Operation code response message header.
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Operation code response message body.
        /// </summary>
        public OperationCodeResponseBody Body { get; set; }
    }

    /// <summary>
    /// Operation code response message body.
    /// </summary>
    public class OperationCodeResponseBody
    {
        /// <summary>
        /// Operation code
        /// </summary>
        public int OperationCode { get; set; }
    }
}