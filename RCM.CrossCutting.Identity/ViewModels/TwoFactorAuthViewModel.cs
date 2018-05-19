using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class TwoFactorAuthViewModel
    {
        [Display(Name = "Segundo Fator de Autenticação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public string Code { get; set; }

        [Display(Name = "Login Persistente")]
        public bool PersistentLogin { get; set; }

        [Display(Name = "Confiar Neste Navegador")]
        public bool RememberClient { get; set; }
    }
}
