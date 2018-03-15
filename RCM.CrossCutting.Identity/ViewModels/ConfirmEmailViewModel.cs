using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class ConfirmEmailViewModel
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [EmailAddress(ErrorMessage = "O email deve estar em um formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Código de Ativação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string Code { get; set; }

        public ConfirmEmailViewModel()
        {

        }

        public ConfirmEmailViewModel(string email)
        {
            Email = email;
        }
    }
}
