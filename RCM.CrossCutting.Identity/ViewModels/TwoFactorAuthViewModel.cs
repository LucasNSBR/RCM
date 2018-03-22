using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class TwoFactorAuthViewModel
    {
        [Display(Name = "Segundo fator de autenticação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string Code { get; set; }

        [Display(Name = "Login persistente")]
        public bool PersistentLogin { get; set; }

        [Display(Name = "Confiar neste navegador")]
        public bool RememberClient { get; set; }
    }
}
