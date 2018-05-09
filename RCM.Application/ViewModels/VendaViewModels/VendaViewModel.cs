using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RCM.Application.ViewModels
{
    public class VendaViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Data da Venda")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data da venda é requerido.")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Detalhes da Venda")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Os detalhes da venda devem ter até 1000 caracteres")]
        public string Detalhes { get; set; }

        [Display(Name = "Produtos")]
        public List<VendaProdutoViewModel> Produtos { get; set; }

        [Display(Name = "Quantidade de Produtos")]
        public int QuantidadeProdutos { get; set; }

        [Display(Name = "Valor total da Venda")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true, DataFormatString = "{0:c}")]
        public decimal TotalVenda { get; set; }

        [Display(Name = "Status da Venda")]
        public VendaStatusEnum Status { get; set; }

        #region Index View Helpers

        #endregion

        public VendaViewModel()
        {
            Produtos = Produtos ?? new List<VendaProdutoViewModel>();
        }
    }
}
