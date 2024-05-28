using System.ComponentModel.DataAnnotations;

namespace Projekti.Models
{
    public class BotimeLibrash
    {
        [Key]
        public int IdBotimi {  get; set; }
        public int IdLibri {  get; set; }
        public Libra? Libra { get; set; }
        public int? NumerKopjesh {  get; set; }
        public int? Viti {  get; set; }
        public string? Formati {  get; set; }
    }
}
