using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class AplicacaoViewModel
    {
        [Key]
        [Display(Name = "Id da Aplicação")]
        public Guid Id { get; set; }

        [Display(Name = "Ano")]
        [Range(0, 2019, ErrorMessage = "O ano deve estar em um formáto válido")]
        public int Ano { get; set; }

        [Display(Name = "Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo marca é requerido.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo marca deve ter entre 4 e 100 caracteres.")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo modelo é requerido.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O campo modelo deve ter entre 5 e 250 caracteres.")]
        public string Modelo { get; set; }

        [Display(Name = "Motor")]
        [StringLength(100, ErrorMessage = "O campo motor deve até 100 caracteres.")]
        public string Motor { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, ErrorMessage = "O campo observação até 1000 caracteres.")]
        public string Observacao { get; set; }

        public Guid ProdutoId { get; set; }
    }
}
