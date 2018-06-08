using RCM.Application.ViewModels.VendaViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Id da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid VendaId { get; set; }

        [Display(Name = "Venda")]
        public VendaViewModel Venda { get; set; }

        [Display(Name = "Detalhes do Serviço")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Os {0} devem ter até {1} caracteres.")]
        public string Detalhes { get; set; }

        [Display(Name = "Valor do Serviço")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal PrecoServico { get; set; }

    }
}
