namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Response message
    /// </summary>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class ResponseBase<TResponseBody> : IResponseWithHeader<ResponseHeader>, 
        IResponseWithBody<TResponseBody>
    {
        /// <summary>
        /// Response message header
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Response message body
        /// </summary>
        public TResponseBody Body { get; set; }
    }
}