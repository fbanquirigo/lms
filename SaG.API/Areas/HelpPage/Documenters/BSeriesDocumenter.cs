using System.Web.Mvc;
using SaG.API.Models;
using SaG.API.Models.Requests.BSeries;
using SaG.API.Models.Responses;

namespace SaG.API.Areas.HelpPage.Documenters
{
	/// <summary>
	/// B series sample document
	/// </summary>
	public class BSeriesDocumenter : APIDocumenter
	{     
		private readonly IResponseHelper responseHelper;
		private readonly UrlHelper urlHelper;

		/// <summary>
		/// Controller Name
		/// </summary>
		protected override string ControllerName
		{
			get { return "BSeries"; }
		}

		/// <summary>
		/// Creates a new instance of BSeriesDocumenter
		/// </summary>
		public BSeriesDocumenter(IResponseHelper responseHelper)
		{
			this.responseHelper = responseHelper;
			this.urlHelper = new UrlHelper();
		}   

		public override void Document()
		{
            SetOpenLockBSamples();
            SetOpenLockNow1BSamples();
		}

		private void SetOpenLockBSamples()
		{
			var sampleRequest = new OpenLockBRequest
								{
                                    LockId = "233493890000",
									Date = "05/06/2014",
									Hour = 9,
									LockStatus = 0,
									TimeBlock = 4,
									TouchKeyId = "C300000018AD830A",
									UserId = "WilsonFG"
								};
			SetSampleRequest(sampleRequest, "OpenLockB");

			const string formRequestFormat =
				"LockId={0}&Date={1}&Hour={2}&LockStatus={3}&TimeBlock={4}&TouchKeyId={5}&UserId={6}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.LockId,
				this.urlHelper.Encode(sampleRequest.Date), sampleRequest.Hour, sampleRequest.LockStatus,
				sampleRequest.TimeBlock, sampleRequest.TouchKeyId, sampleRequest.UserId);
            SetSampleRequest(formRequest, "OpenLockB");

			var responseBody = new OperationCodeResponseBody {OperationCode = 52946783};
			var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
				ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockB");
		}

        private void SetOpenLockNow1BSamples()
        {
            var sampleRequest = new OpenLockNow1BRequest
            {
                LockId = "235108754400",
                UserId = "WilsonFG"
            };
            SetSampleRequest(sampleRequest, "openLockNow1B");

            const string formRequestFormat =
                "LockId={0}&UserId={1}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.LockId, sampleRequest.UserId);
            SetSampleRequest(formRequest, "openLockNow1B");

            var responseBody = new OperationCodeResponseBody { OperationCode = 16295802 };
            var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
                ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "openLockNow1B");
        }
	}
}