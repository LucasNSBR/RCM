using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class FornecedorViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome deve ter entre 10 e 100 caracteres.")]
        public string Nome { get; set; }

        public ICollection<DuplicataViewModel> Duplicatas { get; set; }
        public ICollection<NotaFiscalViewModel> NotasFiscais { get; set; }
    }
}