using System.Web.Mvc;
using SaG.API.Models;
using SaG.API.Models.Requests.BSeries;
using SaG.API.Models.Responses;

namespace SaG.API.Areas.HelpPage.Documenters
{
	/// <summary>
	/// B series sample document
	/// </summary>
	public class CSeriesDocumenter : APIDocumenter
	{     
		private readonly IResponseHelper responseHelper;
		private readonly UrlHelper urlHelper;

		/// <summary>
		/// Controller Name
		/// </summary>
		protected override string ControllerName
		{
			get { return "CSeries"; }
		}

		/// <summary>
		/// Creates a new instance of BSeriesDocumenter
		/// </summary>
		public CSeriesDocumenter(IResponseHelper responseHelper)
		{
			this.responseHelper = responseHelper;
			this.urlHelper = new UrlHelper();
		}   

		public override void Document()
		{
            SetOpenLockCSamples();
		}

		private void SetOpenLockCSamples()
		{
			var sampleRequest = new OpenLockCRequest
								{
                                    AtmId = "233493890000",
									Date = "05/06/2014",
									Hour = 9,
									LockStatus = 0,
									TimeBlock = 4,
									TouchKeyId = "C300000018AD830A",
									MiddleName = ""
								};
			SetSampleRequest(sampleRequest, "OpenLockC");

			const string formRequestFormat =
				"AtmId={0}&Date={1}&Hour={2}&LockStatus={3}&TimeBlock={4}&TouchKeyId={5}&UserId={6}";

            var formRequest = string.Format(formRequestFormat, sampleRequest.AtmId,
				this.urlHelper.Encode(sampleRequest.Date), sampleRequest.Hour, sampleRequest.LockStatus,
				sampleRequest.TimeBlock, sampleRequest.TouchKeyId, sampleRequest.MiddleName);
            SetSampleRequest(formRequest, "OpenLockC");

			var responseBody = new OperationCodeResponseBody {OperationCode = 52946783};
			var response = this.responseHelper.CreateResponse<OperationCodeResponse, OperationCodeResponseBody>(string.Empty,
				ResponseStatus.Ok, responseBody);

            SetSampleResponse(response, "OpenLockC");
		}
	}
}