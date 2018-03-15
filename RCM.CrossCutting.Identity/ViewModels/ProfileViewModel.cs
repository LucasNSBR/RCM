using RCM.CrossCutting.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace RCM.CrossCutting.Identity.ViewModels
{
    public class ProfileViewModel
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

        public ProfileViewModel()
        {
        }

        public ProfileViewModel(RCMIdentityUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
        }
    }
}
