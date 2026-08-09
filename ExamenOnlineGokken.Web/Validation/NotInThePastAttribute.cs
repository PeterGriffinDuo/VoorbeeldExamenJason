using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.Validation
{
    public class NotInThePastAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue && dateValue.Date < DateTime.Today)
            {
                return new ValidationResult(
                    ErrorMessage ?? $"{validationContext.MemberName} mag niet in het verleden liggen.");
            }

            return ValidationResult.Success;
        }
    }
}
