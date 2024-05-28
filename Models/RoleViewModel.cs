using System.ComponentModel.DataAnnotations;
namespace Projekti.Models
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}
