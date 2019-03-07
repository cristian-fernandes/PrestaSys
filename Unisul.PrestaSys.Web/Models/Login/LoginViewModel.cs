using System.ComponentModel.DataAnnotations;
using Unisul.PrestaSys.Web.Models.Base;

namespace Unisul.PrestaSys.Web.Models.Login
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o e-mail para logar.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha para logar.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
