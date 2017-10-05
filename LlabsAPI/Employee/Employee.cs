
using System.ComponentModel.DataAnnotations;

namespace LlabsDomain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="Nome deve ser informado!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email deve ser informado!")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Departamento deve ser informado!")]
        [Display(Name = "Departamento")]
        public string Department { get; set; }
    }
}
