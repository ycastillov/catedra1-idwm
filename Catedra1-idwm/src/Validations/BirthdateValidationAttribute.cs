using System.ComponentModel.DataAnnotations;


namespace Catedra1_idwm.src.Validations
{
    public class BirthdateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime? birthdate = value as DateTime?;

        if (birthdate.HasValue && birthdate.Value >= DateTime.Now)
        {
            return new ValidationResult("La fecha de nacimiento debe ser menor a la fecha actual.");
        }

        return ValidationResult.Success;
    }
}
}