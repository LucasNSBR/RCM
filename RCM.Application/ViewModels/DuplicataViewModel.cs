using RCM.Application.ViewModels.ValueObjectViewModels;
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string Observacao { get; set; }

        [Display(Name = "Id da Nota Fiscal")]
        public string NotaFiscalId { get; set; }

        [Display(Name = "Emissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public decimal Valor { get; set; }

        [Display(Name = "Id do Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }

        [Display(Name = "Pagamento")]
        public PagamentoViewModel Pagamento { get; set; }

        #region Index View Helpers
        public bool Vencido
        {
            get
            {
                return Pagamento == null && DateTime.Now > DataVencimento;
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
