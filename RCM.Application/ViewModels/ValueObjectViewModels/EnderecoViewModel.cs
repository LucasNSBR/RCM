using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ValueObjectViewModels
{
    public class EnderecoViewModel
    {
        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int Numero { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string Complemento { get; set; }

        [Display(Name = "Id da Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid CidadeId { get; set; }

        [Display(Name = "Cidade")]
        public CidadeViewModel Cidade { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string CEP { get; set;  }
    }
}