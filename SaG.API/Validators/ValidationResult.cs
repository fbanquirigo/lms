namespace SaG.API.Validators
{
    public class ValidationResult
    {
        public ValidationResultStatus Result { get; private set; }

        public string Message { get; private set; }

        public ValidationResult(ValidationResultStatus result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}