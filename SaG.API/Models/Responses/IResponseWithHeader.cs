namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Response message with header
    /// </summary>
    /// <typeparam name="THeader">THeader</typeparam>
    public interface IResponseWithHeader<THeader>
    {
        /// <summary>
        /// Response message header
        /// </summary>
        THeader Header { get; set; } 
    }
}