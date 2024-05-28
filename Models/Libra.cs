using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekti.Models
{
    public class Libra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Titulli {  get; set; }
        public int? AutoreId { get; set; }
        public virtual Autore? Autore { get; set; }
        public int? ZhanriId {  get; set; }
        public virtual Zhanre? Zhanri { get; set; }
        public int Viti { get; set; }
        public int? ShtepiBotueseId { get; set; }
        public virtual ShtepiBotuese? ShtepiBotuese { get; set; }
        public decimal Cmimi { get; set; }
        public string? Pershkrimi { get; set; }
    }
}
