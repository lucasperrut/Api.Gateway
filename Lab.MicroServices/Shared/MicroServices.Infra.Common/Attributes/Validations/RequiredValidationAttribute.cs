using MicroServices.Infra.Common.Validations;
using System;

namespace MicroServices.Infra.Common.Attributes.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredValidationAttribute : ValidationBaseAttribute
    {
        public RequiredValidationAttribute() : base(new RequiredValidation())
        {
        }

        public override void Validate(dynamic value)
        {
            if (!Validation.IsValid(value))
                throw new NotImplementedException();
        }
    }
}
