using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class DuplicataViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do documento é requerido.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo número do documento deve ter entre 5 e 20 caracteres.")]
        public string NumeroDocumento { get; set; }

        public string NotaFiscal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataEmissao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O fornecedor relacionado é requerido.")]
        public int FornecedorId { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo valor deve ser estar entre 0 e 99999.")]
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }
}
