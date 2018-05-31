using RCM.CrossCutting.Identity.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class UserViewModel 
    {
        [Display(Name = "Usuário")]
        public RCMIdentityUser User { get; set; }
        
        [Display(Name = "Permissões")]
        public List<string> Roles { get; set; }
    }
}
