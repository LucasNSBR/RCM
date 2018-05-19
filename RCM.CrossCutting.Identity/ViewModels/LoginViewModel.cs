using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [EmailAddress(ErrorMessage = "O {0} deve estar em um formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A {0} deve ter entre {1} e {2} caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Login persistente")]
        public bool PersistentLogin { get; set; }
    }
}
