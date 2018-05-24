using RCM.Domain.Models.ChequeModels.ChequeStates;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ChequeViewModels
{
    public class EstadoChequeViewModel
    {
        [Display(Name = "Id do Cheque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid ChequeId { get; set; }

        [Display(Name = "Situação Atual")]
        public EstadoChequeEnum Estado { get; private set; }

        [Display(Name = "Data do Evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public DateTime DataEvento { get; set; } = DateTime.Now;

        [Display(Name = "Motivo")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string Motivo { get; set; }

        [Display(Name = "Id do Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }
    }
}
