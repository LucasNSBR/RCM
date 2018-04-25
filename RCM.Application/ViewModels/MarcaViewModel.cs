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
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "O campo nome deve ter até 1000 caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        public string Nome { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "O campo observação deve ter até 1000 caracteres.")]
        public string Observacao { get; set; }

        public List<ProdutoViewModel> Produtos { get; set; }
    }
}
