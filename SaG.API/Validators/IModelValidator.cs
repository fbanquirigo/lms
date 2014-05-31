namespace SaG.API.Validators
{
    public interface IModelValidator<in TModel>
    {
        ValidationResult Validate(TModel model);

        ValidationResult Validate(TModel model, MethodType methodType);
    }
}