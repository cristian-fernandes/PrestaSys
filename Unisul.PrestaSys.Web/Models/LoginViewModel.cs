using System.ComponentModel.DataAnnotations;

namespace Unisul.PrestaSys.Web.Models
{
    public class LoginViewModel
    {
        [Required] [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
