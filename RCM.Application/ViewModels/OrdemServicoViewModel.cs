using RCM.Application.ViewModels.ProdutoViewModels;
using RCM.Domain.Models.OrdemServicoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class OrdemServicoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Status da Ordem de Serviço")]
        public OrdemServicoStatus Status { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Produtos")]
        public virtual List<ProdutoViewModel> Produtos { get; set; }

        [Display(Name = "Data de entrada")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data de entrada")]
        public DateTime? DataSaida { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo total é requerido.")]
        [Range(0, 99999, ErrorMessage = "O campo valor deve ser estar entre 0 e 99999.")]
        public decimal Total { get; set; }

        public OrdemServicoViewModel()
        {
            Produtos = new List<ProdutoViewModel>();
        }
    }
}
