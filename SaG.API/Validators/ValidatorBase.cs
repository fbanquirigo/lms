namespace SaG.API.Validators
{
    public abstract class ValidatorBase<TModel> : IModelValidator<TModel>
    {      
        public abstract ValidationResult Validate(TModel model);

        public abstract ValidationResult Validate(TModel model, MethodType methodType);

        protected ValidationResult InvalidResult(string message)
        {
            return new ValidationResult(ValidationResultStatus.Invalid, message);   
        }

        protected ValidationResult ValidResult()
        {
            return ValidResult(null);
        }

        protected ValidationResult ValidResult(string message)
        {
            return new ValidationResult(ValidationResultStatus.Valid, message);
        }

        protected ValidationResult ErrorResult(string message)
        {
            return new ValidationResult(ValidationResultStatus.Error, message);
        }
    }
}