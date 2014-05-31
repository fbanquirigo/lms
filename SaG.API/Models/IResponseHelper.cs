using SaG.API.Models.Responses;

namespace SaG.API.Models
{
    public interface IResponseHelper
    {
        TResponse CreateResponse<TResponse, TResponseBody>(string message,
            ResponseStatus status, TResponseBody body)
            where TResponse : IResponseWithHeader<ResponseHeader>, IResponseWithBody<TResponseBody>, new();

        TResponse CreateResponse<TResponse>(string message,
            ResponseStatus status)
            where TResponse : IResponseWithHeader<ResponseHeader>, new();

        TResponse CreateResponse<TResponse, TResponseBody>(TResponseBody body)
            where TResponse : IResponseWithHeader<ResponseHeader>, IResponseWithBody<TResponseBody>, new();

        TResponse CreateResponse<TResponse, TResponseHeader, TResponseBody>(TResponseHeader header,
            TResponseBody body)
            where TResponse : IResponseWithHeader<TResponseHeader>, IResponseWithBody<TResponseBody>, new();

        TResponse CreateUnhandledResponse<TResponse>(string errorId)
            where TResponse : IResponseWithHeader<ResponseHeader>, new();
    }
}