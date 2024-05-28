using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projekti.ValidimeTePersonalizuara;

namespace Projekti.Models
{
    public class Kontakt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Required(ErrorMessage = "{0} eshte i detyrueshem")]
        [FillonMeShkronjeTeMadhe] //Validator i personalizuar
        public string? Emer {  get; set; }
        [Required(ErrorMessage = "{0} eshte i detyrueshem")]
        [FillonMeShkronjeTeMadhe] //Validator i personalizuar
        public string? Mbiemer {  get; set; }
        [Required(ErrorMessage = "{0} eshte e detyrueshme")]
        [Range(16, 100)]
        public int Mosha { get; set; }
        [Required(ErrorMessage = "{0} eshte e detyrueshme")]
        [ValidimGjinie] //Validator i personalizuar
        public string Gjinia {  get; set; }
        [Required(ErrorMessage = "{0} eshte i detyrueshem")]
        [EmailAddress]
        public string? Email {  get; set; }
        [Required(ErrorMessage = "{0} eshte i detyrueshem")]
        [Phone]
        [Display(Name = "Numri i telefonit")]
        [ValidimNumerTelefoni] //Validator i personalizuar
        public string? NumerTelefoni {  get; set; }
        [Required(ErrorMessage = "Ju lutem lini nje mesazh te kuptueshem")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Mesazhi duhet te kete gjatesi nga 10 ne 100 karaktere.")]
        public string? Mesazhi {  get; set; }

    }
}
