using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Senha Atual")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
        public string CurrentPassword { get; set; }

        [Display(Name = "Nova Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar Nova Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Compare("NewPassword", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmNewPassword { get; set; }
    }
}
