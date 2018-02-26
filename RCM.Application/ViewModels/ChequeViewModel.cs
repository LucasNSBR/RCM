using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ChequeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O banco relacionado é requerido.")]
        public int BancoId { get; set; }
        public BancoViewModel Banco { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo agência é requerido.")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "O campo agência deve ter entre 4 e 5 caracteres.")]
        public string Agencia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo conta é requerido")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "O campo conta deve ter entre 6 e 10 caracteres.")]
        public string Conta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do cheque é requerido")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "O campo número do cheque deve ter entre 6 e 10 caracteres.")]
        public string NumeroCheque { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataEmissao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de vencimento é requerido.")]
        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo valor deve ser estar entre 0 e 99999.")]
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return NumeroCheque;
        }
    }
}
