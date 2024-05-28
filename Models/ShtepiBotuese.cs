using System.ComponentModel.DataAnnotations;

namespace Projekti.Models
{
    public class ShtepiBotuese
    {
        public int Id {  get; set; }
        [Display(Name = "Shtepia Botuese")]
        public string? ShtepiaBotuese {  get; set; }
        public string? Vendodhja {  get; set; }
    }
}
