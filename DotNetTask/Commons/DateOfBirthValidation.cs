using System.ComponentModel.DataAnnotations;

namespace DotNetTask.Commons;

public class DateOfBirthValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date of birth is required.");
        }

        if (!(value is DateTime))
        {
            return new ValidationResult("Invalid date format.");
        }

        DateTime dateOfBirth = (DateTime)value;
        DateTime today = DateTime.Today;

        if (dateOfBirth > today)
        {
            return new ValidationResult("Date of birth cannot be in the future.");
        }

        if (dateOfBirth < today.AddYears(-150)) // assuming 150 years as a reasonable age limit
        {
            return new ValidationResult("Date of birth is not realistic.");
        }

        return ValidationResult.Success;
    }
}