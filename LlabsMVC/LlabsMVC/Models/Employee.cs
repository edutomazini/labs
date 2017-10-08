
using System.ComponentModel.DataAnnotations;

namespace LlabsDomain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name must be informed!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email must be informed!")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Department must be informed!")]
        [Display(Name = "Departamento")]
        public string Department { get; set; }
    }
}
