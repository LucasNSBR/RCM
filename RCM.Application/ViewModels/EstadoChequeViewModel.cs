using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EstadoChequeViewModel
    {
        [Display(Name = "Id do Cheque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cheque relacionado é requerida.")]
        public Guid ChequeId { get; set; }

        [Display(Name = "Data do Evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data do evento é requerido.")]
        public DateTime DataEvento { get; set; }

        [Display(Name = "Motivo")]
        public string Motivo { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Situação Atual")]
        public string Estado { get; set; }
    }
}
