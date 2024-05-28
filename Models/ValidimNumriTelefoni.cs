using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Projekti.ValidimeTePersonalizuara 
{
    public class ValidimNumerTelefoni : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        { 
            if (value is string numerTelefoni)
            {
                if (Regex.IsMatch(numerTelefoni, @"^(067|068|069)\d{7}$"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Numri i telefonit duhet te filloje me '067', '068' ose '069' dhe te perbehet nga 10 shifra.");
                }
            }

            return new ValidationResult("Numri i telefonit duhet te filloje me '067', '068' ose '069' dhe te perbehet nga 10 shifra.");
        }
    }   
}
