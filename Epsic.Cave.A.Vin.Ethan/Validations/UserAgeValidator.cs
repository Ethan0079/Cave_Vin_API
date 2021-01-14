using System.ComponentModel.DataAnnotations;

public class UserAgeValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var age = (int)value;

        if (age >= 16)
            return ValidationResult.Success;
            
        return new ValidationResult("Désolé vous n'avez pas l'âge pour posséder du vin !");
    }
}