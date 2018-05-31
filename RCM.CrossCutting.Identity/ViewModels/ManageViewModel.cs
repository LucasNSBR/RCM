using RCM.CrossCutting.Identity.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class ManageViewModel
    {
        [Display(Name = "Autenticação em dois fatores")]
        public bool TwoFactorActivated { get; set; }

        [Display(Name = "Confirmação de e-mail")]
        public bool ConfirmedEmail { get; set; }

        [Display(Name = "Minhas Permissões")]
        public List<string> Roles { get; set; }
        
        public ManageViewModel()
        {
            Roles = new List<string>();
        }
    }
}
