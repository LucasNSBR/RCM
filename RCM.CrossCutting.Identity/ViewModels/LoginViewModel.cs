using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [EmailAddress(ErrorMessage = "O email deve estar em um formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Login persistente")]
        public bool PersistentLogin { get; set; }
    }
}
