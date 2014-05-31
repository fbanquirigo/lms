using System.Web.Compilation;
using SaG.API.Helpers;
using SaG.API.Models.Requests;
using SaG.API.Models.Requests.ASeries;

namespace SaG.API.Validators
{
    public class CloseCodeRequestValidator : ValidatorBase<ICloseCodeRequest>
    {
        private readonly IResourceProvider resourceProvider;

        public CloseCodeRequestValidator(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public override ValidationResult Validate(ICloseCodeRequest model)
        {
            if (model == null)
                return ErrorResult(this.resourceProvider.ResourceString("InvalidRequest.Error"));
            return ValidResult();
        }

        public override ValidationResult Validate(ICloseCodeRequest model, MethodType methodType)
        {
            switch (methodType)
            {
                case MethodType.CLOSE_CODE_A:
                    return ValidateCloseCodeA(model as CloseCodeARequest);
                case MethodType.CLOSE_CODE_A_SEAL_A:
                    return ValidateCloseCodeViaSealA(model as CloseCodeViaSealARequest);
                default:
                    string errorFormat = this.resourceProvider.ResourceString("ValidatorMethodType.Format.Error");
                    string error = string.Format(errorFormat, GetType().FullName, methodType);
                    return InvalidResult(error);
            }
        }

        private ValidationResult ValidateCloseCodeA(CloseCodeARequest model)
        {
            if (model.AtmId == null || model.OperationResult == null || model.OperationCode == 0)
                return InvalidResult(this.resourceProvider.ResourceString("RequiredFields.Error"));
            return ValidResult();
        }

        private ValidationResult ValidateCloseCodeViaSealA(CloseCodeViaSealARequest model)
        {
            if (model.UserId == null || model.OperationResult == null)
                return InvalidResult(this.resourceProvider.ResourceString("RequiredFields.Error"));
            return ValidResult();
        }
    }
}