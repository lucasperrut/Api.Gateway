using MicroServices.Infra.Common.Validations;
using System;

namespace MicroServices.Infra.Common.Attributes.Validations
{
    public abstract class ValidationBaseAttribute : Attribute
    {
        protected IValidation Validation;

        public ValidationBaseAttribute(IValidation validation)
        {
            Validation = validation;
        }

        public abstract void Validate(dynamic value);
    }
}
