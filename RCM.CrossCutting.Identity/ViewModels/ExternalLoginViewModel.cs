using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class ExternalLoginViewModel
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
    }
}
