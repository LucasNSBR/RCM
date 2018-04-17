using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo nome deve ter entre 5 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Aplicação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo aplicação é requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo aplicação deve ter entre 10 e 1000 caracteres.")]
        public string Aplicacao { get; set; }

        [Display(Name = "Quantidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo quantidade é requerido.")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo preço de venda é requerido.")]
        public decimal PrecoVenda { get; set; }

        //[Display(Name = "Fornecedores")]
        //public List<FornecedorViewModel> Fornecedores { get; set; }

        [Display(Name = "Id da Marca")]
        public Guid MarcaId { get; set; }

        [Display(Name = "Marcas")]
        public MarcaViewModel Marca { get; set; }
    }
}
