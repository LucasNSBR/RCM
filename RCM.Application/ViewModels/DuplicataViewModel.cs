using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class DuplicataViewModel
    {
        [Display(Name = "Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Número do Documento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do documento é requerido.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo número do documento deve ter entre 5 e 20 caracteres.")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Id da Nota Fiscal")]
        public int NotaFiscalId { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Nota Fiscal")]
        public NotaFiscalViewModel NotaFiscal { get; set; }

        [Display(Name = "Emissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        [Display(Name = "Id do Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O fornecedor relacionado é requerido.")]
        public int FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        [Range(0, 99999, ErrorMessage = "O campo valor deve ser estar entre 0 e 99999.")]
        public decimal Valor { get; set; }
    }
}
