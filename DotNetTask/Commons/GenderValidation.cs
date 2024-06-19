using System.ComponentModel.DataAnnotations;

namespace DotNetTask.Commons;

public class GenderValidation : ValidationAttribute
{
    private readonly string[] _allowedGenders;

    public GenderValidation(params string[] allowedGenders)
    {
        _allowedGenders = allowedGenders;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        string input = value as string;
        if (string.IsNullOrEmpty(input))
        {
            return new ValidationResult("The gender field cannot be null or empty.");
        }

        if (!_allowedGenders.Contains(input, StringComparer.OrdinalIgnoreCase))
        {
            return new ValidationResult(
                $"The gender field must be one of the following values: {string.Join(", ", _allowedGenders)}.");
        }

        return ValidationResult.Success;
    }
}