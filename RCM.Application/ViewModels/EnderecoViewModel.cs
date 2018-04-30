using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número é requerido.")]
        [Range(0, 9999, ErrorMessage = "O campo número deve ter entre 1 e 4 caracteres.")]
        public int Numero { get; set; }

        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo rua é requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo rua deve ter entre 5 e 100 caracteres.")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo bairro é requerido.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O campo bairro deve ter entre 5 e 25 caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O campo complemento deve ter até 100 caracteres.")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 0, ErrorMessage = "O campo CEP deve ter até 8 caracteres.")]
        public string CEP { get; set;  }
    }
}