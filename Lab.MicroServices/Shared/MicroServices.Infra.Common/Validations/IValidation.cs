namespace MicroServices.Infra.Common.Validations
{
    public interface IValidation
    {
        bool IsValid(dynamic value);
    }
}
