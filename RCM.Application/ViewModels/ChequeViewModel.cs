using RCM.Domain.Models.ChequeModels.ChequeStates;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ChequeViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Id do Banco")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O banco relacionado é requerido.")]
        public Guid BancoId { get; set; }

        [Display(Name = "Banco")]
        public BancoViewModel Banco { get; set; }

        [Display(Name = "Agência")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo agência é requerido.")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "O campo agência deve ter entre 4 e 5 caracteres.")]
        public string Agencia { get; set; }

        [Display(Name = "Conta Bancária")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo conta é requerido")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "O campo conta deve ter entre 6 e 10 caracteres.")]
        public string Conta { get; set; }

        [Display(Name = "Número do Cheque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo número do cheque é requerido")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "O campo número do cheque deve ter entre 6 e 10 caracteres.")]
        public string NumeroCheque { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Emissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de emissão é requerido.")]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de vencimento é requerido.")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor é requerido.")]
        public decimal Valor { get; set; }

        [Display(Name = "Situação")]
        public EstadoChequeViewModel EstadoCheque { get; set; }

        #region Index View Helpers
        public bool ItemRequerAtencao
        {
            get
            {
                return DateTime.Now > DataVencimento &&
                    (EstadoCheque == null ||
                    EstadoCheque?.Estado == EstadoChequeEnum.Bloqueado);
            }
        }

        public bool ItemProblema
        {
            get
            {
                return DateTime.Now > DataVencimento &&
                    (EstadoCheque == null ||
                    EstadoCheque?.Estado == EstadoChequeEnum.Devolvido ||
                    EstadoCheque?.Estado == EstadoChequeEnum.Sustado);
            }
        }

        public bool ItemBom
        {
            get
            {
                return DateTime.Now > DataVencimento &&
                    (EstadoCheque != null &&
                    EstadoCheque?.Estado == EstadoChequeEnum.Repassado ||
                    EstadoCheque?.Estado == EstadoChequeEnum.Compensado);
            }
        }
        #endregion
    }
}
