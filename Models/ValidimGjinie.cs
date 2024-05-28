using System.ComponentModel.DataAnnotations;

namespace Projekti.ValidimeTePersonalizuara
{
    public class ValidimGjinie : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string gjinia)
            {
                if (gjinia.ToUpper() == "M" || gjinia.ToUpper() == "F")
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Gjinia duhet te jete 'M' ose 'F'.");
                }
            }

            return new ValidationResult("Gjinia duhet te jete 'M' ose 'F'.");
        }
    }
}
