using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.Validation
{
    public class RequireEitherAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public RequireEitherAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);
            var otherValue = otherPropertyInfo?.GetValue(validationContext.ObjectInstance) as string;

            if (string.IsNullOrWhiteSpace(value as string) && string.IsNullOrWhiteSpace(otherValue))
            {
                return new ValidationResult(
                    ErrorMessage ?? $"Vul minstens {validationContext.MemberName} of {_otherProperty} in.");
            }

            return ValidationResult.Success;
        }
    }
}
