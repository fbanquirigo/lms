using System.Web.Mvc;
using SaG.API.Models;
using SaG.API.Models.Requests.ASeries;
using SaG.API.Models.Responses;

namespace SaG.API.Areas.HelpPage.Documenters
{
	/// <summary>
	/// A Series sample documentation
	/// </summary>
	public class ASeriesDocumenter : APIDocumenter
	{
		private readonly IResponseHelper responseHelper;
        private readonly UrlHelper urlHelper;

        /// <summary>
        /// Controller Name
        /// </summary>
		protected override string ControllerName
		{
			get { return "ASeries"; }
		}

		/// <summary>
		/// Creates a new instance of ASeriesDocumenter
		/// </summary>
		public ASeriesDocumenter(IResponseHelper responseHelper)
		{
			this.responseHelper = responseHelper;
            this.urlHelper = new UrlHelper();
		}   

		public override void Document()
		{
			SetOpenLockASamples();
		    SetOpenLockNoTouchKeyASamples();
		    SetOpenLockNowASamples();
            SetOpenLockNow2ASamples();
		    SetCloseCodeASamples();
		    SetCloseCodeViaSealASamples();
		}

		private void SetOpenLockASamples()
		{
            var sampleRequest = new OpenLockARequest
                                {
                                    AtmId = "23349389",
                                    Date = "05/06/2014",
                                    Hour = 9,
                                    LockStatus = 0,
                                    TimeBlock = 4,
                                    TouchKeyId = "C300000018AD830A",
                                    UserId = "WilsonFG"
                                };
            SetSampleRequest(sampleRequest, "OpenLockA");

		    const string formRequestFormat =
		        "AtmId={0}&Date={1}&Hour={2}&LockStatus={3}&TimeBlock={4}&TouchKeyId={5}&UserId={6}";

		    var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId,
                this.urlHelper.Encode(sampleRequest.Date), sampleRequest.Hour, sampleRequest.LockStatus,
		        sampleRequest.TimeBlock, sampleRequest.TouchKeyId, sampleRequest.UserId);
            SetSampleRequest(formRequest, "OpenLockA");

		    var responseBody = new OperationCodeResponseBody {OperationCode = 52946783};
            var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockA");
		}

	    private void SetOpenLockNoTouchKeyASamples()
	    {
	        var sampleRequest = new OpenLockNoTouchKeyARequest
	                            {
	                                AtmId = "23349389",
	                                Date = "05/06/2014",
	                                Hour = 9,
	                                TimeBlock = 4,
	                                UserId = "WilsonFG"
	                            };
            SetSampleRequest(sampleRequest, "OpenLockNoTouchKeyA");

            const string formRequestFormat =
                "AtmId={0}&Date={1}&Hour={2}&TimeBlock={3}&UserId={4}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId,
                this.urlHelper.Encode(sampleRequest.Date), sampleRequest.Hour, sampleRequest.TimeBlock, sampleRequest.UserId);
            SetSampleRequest(formRequest, "OpenLockNoTouchKeyA");

            var responseBody = new OperationCodeResponseBody { OperationCode = 52946783 };
            var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockNoTouchKeyA");
	    }

	    private void SetOpenLockNowASamples()
	    {
            var sampleRequest = new OpenLockNowARequest
            {
                AtmId = "23349389",
                UserId = "WilsonFG"
            };
            SetSampleRequest(sampleRequest, "OpenLockNowA");

            const string formRequestFormat =
                "AtmId={0}&UserId={1}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId, sampleRequest.UserId);
            SetSampleRequest(formRequest, "OpenLockNowA");

            var responseBody = new OperationCodeResponseBody { OperationCode = 52946783 };
            var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockNowA");
	    }

        private void SetOpenLockNow2ASamples()
        {
            var sampleRequest = new OpenLockNow2ARequest
            {
                AtmId = "23349389",
                UserId = "WilsonFG"
            };
            SetSampleRequest(sampleRequest, "OpenLockNow2A");

            const string formRequestFormat =
                "AtmId={0}&UserId={1}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId, sampleRequest.UserId);
            SetSampleRequest(formRequest, "OpenLockNow2A");

            var responseBody = new OperationCodeResponseBody { OperationCode = 46366675 };
            var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockNow2A");
        }

	    private void SetCloseCodeASamples()
	    {
	        var sampleRequest = new CloseCodeARequest
	                            {
	                                AtmId = "23349389",
	                                OperationResult = "0",
	                                OperationCode = 52946783
	                            };

            SetSampleRequest(sampleRequest, "CloseCodeA");

	        const string formRequestFormat = "AtmId={0}&OperationResult={1}&OperationCode={2}";
	        var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId, sampleRequest.OperationResult,
	            sampleRequest.OperationCode);
            SetSampleRequest(formRequest, "CloseCodeA");

            var responseBody = new CloseCodeResponseBody { CodeClosed = true };
            var response = this.responseHelper.CreateResponse<CloseCodeResponse, CloseCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "CloseCodeA");
	    }

	    private void SetCloseCodeViaSealASamples()
	    {
            var sampleRequest = new CloseCodeViaSealARequest
            {
                UserId = "WilsonFG",
                OperationResult = "0",
            };

            SetSampleRequest(sampleRequest, "CloseCodeViaSealA");
                                                                   
            const string formRequestFormat = "UserId={0}&OperationResult={1}";
            var formRequest = string.Format(formRequestFormat, sampleRequest.UserId, sampleRequest.OperationResult);
            SetSampleRequest(formRequest, "CloseCodeViaSealA");

            var responseBody = new CloseCodeResponseBody { CodeClosed = true };
            var response = this.responseHelper.CreateResponse<CloseCodeResponse, CloseCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "CloseCodeViaSealA"); 
	    }
	}
}