using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 15 carateres.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 50 carateres.")]
        public string LastName { get; set; }

        [Display(Name = "Idade")]
        [Range(18, 80, ErrorMessage = "A idade deve estar em um formato válido.")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [EmailAddress(ErrorMessage = "O email deve estar em um formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 24 caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
