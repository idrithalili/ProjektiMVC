using System.ComponentModel.DataAnnotations;

namespace Projekti.ValidimeTePersonalizuara {
    public class FillonMeShkronjeTeMadhe : RegularExpressionAttribute
    {
        public FillonMeShkronjeTeMadhe() : base("^[A-Z][a-z]*$")
        {
            ErrorMessage = "Fusha tekst duhet te filloje me te madhe.";
        }
    }
}
