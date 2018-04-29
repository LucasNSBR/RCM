using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class DuplicataViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Número do Documento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do documento é requerido.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo número do documento deve ter entre 5 e 20 caracteres.")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Id da Nota Fiscal")]
        public Guid? NotaFiscalId { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "O campo observação deve ter até 1000 caracteres.")]
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
        
        [Display(Name = "Id do Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O fornecedor relacionado é requerido.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }

        [Display(Name = "Pagamento")]
        public PagamentoViewModel Pagamento { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        public decimal Valor { get; set; }

        #region Index View Helpers
        public bool Vencido
        {
            get
            {
                return Pagamento == null && DataVencimento < DateTime.Now;
            }
        }

        public bool Pago
        {
            get
            {
                return Pagamento != null;
            }
        }
        #endregion
    }
}
