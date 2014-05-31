namespace SaG.API.Models.Responses
{
    /// <summary>
    /// Response message with body
    /// </summary>
    /// <typeparam name="TBody">TBody</typeparam>
    public interface IResponseWithBody<TBody>
    {
        /// <summary>
        /// Response message body
        /// </summary>
        TBody Body { get; set; }         
    }
}