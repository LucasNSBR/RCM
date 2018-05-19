using RCM.Application.ViewModels.ProdutoViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class MarcaViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public string Nome { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string Observacao { get; set; }

        [Display(Name = "Produtos")]
        public List<ProdutoViewModel> Produtos { get; set; }
    }
}
