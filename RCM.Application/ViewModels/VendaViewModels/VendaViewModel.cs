using RCM.Domain.Models.VendaModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.VendaViewModels
{
    public class VendaViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Data da Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }

        [Display(Name = "Detalhes da Venda")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Os {0} devem ter até {1} caracteres")]
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

        [Display(Name = "Condições de Pagamento")]
        public CondicaoPagamentoViewModel CondicaoPagamento { get; set; }
    }
}
