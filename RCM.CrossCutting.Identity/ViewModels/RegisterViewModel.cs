using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} carateres.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O {0} deve ter entre {2} e {1} carateres.")]
        public string LastName { get; set; }

        [Display(Name = "Idade")]
        [Range(18, 80, ErrorMessage = "A {0} deve estar em um formato válido.")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [EmailAddress(ErrorMessage = "O {0} deve estar em um formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
