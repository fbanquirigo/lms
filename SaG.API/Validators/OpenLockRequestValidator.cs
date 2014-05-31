using System.Web.Compilation;
using SaG.API.Helpers;
using SaG.API.Models.Requests;
using SaG.API.Models.Requests.ASeries;

namespace SaG.API.Validators
{
    public class OpenLockRequestValidator : ValidatorBase<IOpenLockARequest>
    {
        private readonly IResourceProvider resourceProvider;

        public OpenLockRequestValidator(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public override ValidationResult Validate(IOpenLockARequest model)
        {
            if (model == null)
                return ErrorResult(this.resourceProvider.ResourceString("InvalidRequest.Error"));

            if (model is OpenLockARequest)
                return ValidateOpenLockA(model as OpenLockARequest);

            if (model is OpenLockNoTouchKeyARequest)
                return ValidateOpenLockNoTouchKeyA(model as OpenLockNoTouchKeyARequest);

            if (model is OpenLockNowARequest)
                return ValidateOpenLockNowA(model as OpenLockNowARequest);
            return ValidResult();
        }

        public override ValidationResult Validate(IOpenLockARequest model, MethodType methodType)
        {
            switch (methodType)
            {
                case MethodType.OPEN_LOCK_A:
                    return ValidateOpenLockA(model as OpenLockARequest);
                case MethodType.OPEN_LOCK_NO_TOUCH_KEY_A:
                    return ValidateOpenLockNoTouchKeyA(model as OpenLockNoTouchKeyARequest);
                case MethodType.OPEN_LOCK_NOW_A:
                    return ValidateOpenLockNowA(model as OpenLockNowARequest);
                default:
                    string errorFormat = this.resourceProvider.ResourceString("ValidatorMethodType.Format.Error");
                    string error = string.Format(errorFormat, GetType().FullName, methodType);
                    return InvalidResult(error);
            }   
        }

        private ValidationResult ValidateOpenLockA(OpenLockARequest model)
        {
            if (model.AtmId == null || model.UserId == null || model.TouchKeyId == null || model.Hour == null
                || model.Date == null || model.TimeBlock == null || model.LockStatus == null)
                return InvalidResult(this.resourceProvider.ResourceString("RequiredFields.Error"));
            return ValidResult();
        }

        private ValidationResult ValidateOpenLockNoTouchKeyA(OpenLockNoTouchKeyARequest model)
        {
            if (model.AtmId == null || model.UserId == null || model.Hour == null 
                || model.Date == null || model.TimeBlock == null)
                return InvalidResult(this.resourceProvider.ResourceString("RequiredFields.Error"));
            return ValidResult();
        }

        private ValidationResult ValidateOpenLockNowA(OpenLockNowARequest model)
        {
            if (model.AtmId == null || model.UserId == null)
                return InvalidResult(this.resourceProvider.ResourceString("RequiredFields.Error"));
            return ValidResult();
        }      
    }
}