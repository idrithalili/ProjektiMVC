using System.ComponentModel.DataAnnotations;

namespace Projekti.Models
{
    public class GjendjeLibrash
    {
        [Key]
        public int IdLibri {  get; set; }
        public int? NumerKopjesh {  get; set; }
        public string? Gjendje {  get; set; }
    }
}
