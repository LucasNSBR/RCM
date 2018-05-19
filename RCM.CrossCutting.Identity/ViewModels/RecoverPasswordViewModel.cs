using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class RecoverPasswordViewModel
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [EmailAddress(ErrorMessage = "O {0} deve estar em um formato válido.")]
        public string Email { get; set; }
    }
}
