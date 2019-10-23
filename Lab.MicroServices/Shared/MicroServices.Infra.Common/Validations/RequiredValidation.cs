namespace MicroServices.Infra.Common.Validations
{
    public class RequiredValidation : IValidation
    {
        public bool IsValid(dynamic value)
        {
            return Valid(value);
        }

        private bool Valid(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
