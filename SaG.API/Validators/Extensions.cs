namespace SaG.API.Validators
{
    public static class Extensions
    {
        public static ValidationResult Validate<TRequest>(
            this IModelValidator<TRequest> validator, TRequest request)
        {
            return validator.Validate(request);
        }

        public static ValidationResult Validate<TRequest>(
            this IModelValidator<TRequest> validator, TRequest request, MethodType methodType)
        {
            return validator.Validate(request, methodType);
        }
    }
}