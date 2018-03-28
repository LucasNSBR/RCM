using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número é requerido.")]
        [Range(0, 9999, ErrorMessage = "O campo número deve ter entre 1 e 4 caracteres.")]
        public int Numero { get; set; }

        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo rua é requerido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo rua deve ter entre 5 e 100 caracteres.")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo bairro é requerido.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "O campo bairro deve ter entre 5 e 25 caracteres.")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo CEP é requerido.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo CEP deve ter 8 caracteres.")]
        public string CEP { get; set;  }

        [Display(Name = "Id da Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A cidade relacionada é requerido.")]
        public Guid CidadeId { get; set; }

        [Display(Name = "Cidade")]
        public CidadeViewModel Cidade { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }
    }
}