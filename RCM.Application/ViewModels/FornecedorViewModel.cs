using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class FornecedorViewModel
    {
        [Display(Name = "Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome deve ter entre 10 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Observações")]
        public string Observacao { get; set; }

        [Display(Name = "Duplicatas")]
        public List<DuplicataViewModel> Duplicatas { get; set; }

        [Display(Name = "Notas Fiscais")]
        public List<NotaFiscalViewModel> NotasFiscais { get; set; }

        [Display(Name = "Produtos")]
        public List<ProdutoViewModel> Produtos { get; set; }
    }
}