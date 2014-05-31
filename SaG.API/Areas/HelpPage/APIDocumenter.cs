using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using SaG.Core;

namespace SaG.API.Areas.HelpPage
{
    /// <summary>
    /// API Documenter
    /// </summary>
    public abstract class APIDocumenter : IApiDocumenter
    {
        private HelpPageSampleGenerator sampleGenerator;
        private HttpConfiguration config;

        /// <summary>
        /// Sample generator
        /// </summary>
        protected HelpPageSampleGenerator SampleGenerator
        {
            get
            {
                this.sampleGenerator = this.sampleGenerator ??
                                       ServiceLocator.Current.GetInstance<HelpPageSampleGenerator>();
                return this.sampleGenerator;
            }    
        }

        /// <summary>
        /// Http configuration
        /// </summary>
        protected HttpConfiguration HttpConfig
        {
            get
            {
                this.config = this.config ?? ServiceLocator.Current.GetInstance<HttpConfiguration>();
                return this.config;
            }
        }

        /// <summary>
        /// Controller Name
        /// </summary>
        protected abstract string ControllerName { get; }

        /// <summary>
        /// Document
        /// </summary>
        public abstract void Document();

        /// <summary>
        /// Set Sample Request
        /// </summary>
        protected void SetSampleRequest<TRequest>(TRequest sample, string actionName)
        {
            foreach (var formatter in HttpConfig.Formatters.Where(x => x.GetType() != typeof(JQueryMvcFormUrlEncodedFormatter)))
            {    
                if(!formatter.CanWriteType(typeof(TRequest)))
                    continue;
                
                foreach (MediaTypeHeaderValue mediaType in formatter.SupportedMediaTypes)
                {
                    var sampleObject = SampleGenerator.WriteSampleObjectUsingFormatter(formatter, sample, 
                        typeof(TRequest), mediaType);
                    HttpConfig.SetSampleRequest(sampleObject, mediaType, ControllerName, actionName);
                }
            }        
        }

        /// <summary>
        /// Set Sample Request
        /// </summary>
        protected void SetSampleRequest(string sample, string actionName)
        {
            var mediaType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpConfig.SetSampleRequest(sample, mediaType, ControllerName, actionName);
        }

        /// <summary>
        /// Set Sample Response
        /// </summary>
        protected void SetSampleResponse<TResponse>(TResponse sample, string actionName)
        {
            foreach (var formatter in HttpConfig.Formatters.Where(x => x.GetType() != typeof(JQueryMvcFormUrlEncodedFormatter)))
            {
                if (!formatter.CanWriteType(typeof(TResponse)))
                    continue;

                foreach (MediaTypeHeaderValue mediaType in formatter.SupportedMediaTypes)
                {
                    var sampleObject = SampleGenerator.WriteSampleObjectUsingFormatter(formatter, sample,
                        typeof(TResponse), mediaType);
                    HttpConfig.SetSampleResponse(sampleObject, mediaType, ControllerName, actionName);
                }
            }    
        }
    }
}