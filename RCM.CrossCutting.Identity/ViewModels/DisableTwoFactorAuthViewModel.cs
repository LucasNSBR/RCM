using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class DisableTwoFactorAuthViewModel
    {
        [Display(Name = "Código de Desativação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string Code { get; set; }
    }
}
