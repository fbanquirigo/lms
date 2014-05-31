using System.Web.Compilation;
using SaG.API.Helpers;
using SaG.API.Models.Responses;

namespace SaG.API.Models
{
    public class ResponseHelper : IResponseHelper
    {
        private readonly IResourceProvider resourceProvider;

        public ResponseHelper(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public TResponse CreateResponse<TResponse, TResponseBody>(string message, 
            ResponseStatus status, TResponseBody body)
            where TResponse : IResponseWithHeader<ResponseHeader>, IResponseWithBody<TResponseBody>, new()
        {
            return new TResponse
            {
                Header = new ResponseHeader
                {
                    Message = message,
                    StatusCode = status,
                    Status = status.ToString()
                },
                Body = body
            };
        }

        public TResponse CreateResponse<TResponse>(string message,
            ResponseStatus status)
            where TResponse : IResponseWithHeader<ResponseHeader>, new()
        {
            return new TResponse
            {
                Header = new ResponseHeader
                {
                    Message = message,
                    StatusCode = status,
                    Status = status.ToString()
                }
            };
        }

        public TResponse CreateResponse<TResponse, TResponseBody>(TResponseBody body) 
            where TResponse : IResponseWithHeader<ResponseHeader>, IResponseWithBody<TResponseBody>, new()
        {
            return new TResponse
            {
                Header = new ResponseHeader
                {
                    StatusCode = ResponseStatus.Ok,
                    Status = ResponseStatus.Ok.ToString()
                },
                Body = body
            };
        }     

        public TResponse CreateResponse<TResponse, TResponseHeader, TResponseBody>(TResponseHeader header, TResponseBody body) 
            where TResponse : IResponseWithHeader<TResponseHeader>, IResponseWithBody<TResponseBody>, new()
        {
            return new TResponse
            {
                Header = header,
                Body = body
            };
        }    


        public TResponse CreateUnhandledResponse<TResponse>(string errorId)
            where TResponse : IResponseWithHeader<ResponseHeader>, new()
        {
            return new TResponse
            {
                Header = new ResponseHeader
                {
                    Message = this.resourceProvider.ResourceString("Unhandled.Error"),
                    StatusCode = ResponseStatus.UnhandledException,
                    Status = ResponseStatus.UnhandledException.ToString(),
                    ErrorId = errorId
                }
            };
        }
    }
}