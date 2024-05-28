using System.ComponentModel.DataAnnotations;

namespace Projekti.Models
{
    public class Autore
    {
        public int Id { get; set; }
        [Display(Name ="Emri i autorit")]
        public string? EmerAutori { get; set; }
        [Display(Name = "Mbiemri i autorit")]
        public string? MbiemerAutori { get; set; }
        public string Autori => $"{EmerAutori} {MbiemerAutori}";
        public string? Vendbanimi {  get; set; }
        //public DateTime Ditelindja { get; set; }
    }
}
