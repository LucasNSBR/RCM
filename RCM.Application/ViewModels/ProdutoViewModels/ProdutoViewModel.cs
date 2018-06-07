using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ProdutoViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Unidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public ProdutoUnidadeEnum Unidade { get; set; }

        [Display(Name = "Ref. do Fabricante")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ReferenciaFabricante { get; set; }

        [Display(Name = "Ref. Original")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ReferenciaOriginal { get; set; }

        [Display(Name = "Ref. Auxiliar")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ReferenciaAuxiliar { get; set; }

        [Display(Name = "Aplicações")]
        public List<AplicacaoViewModel> Aplicacoes { get; set; }

        [Display(Name = "Estoque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int Estoque { get; set; }

        [Display(Name = "Estoque Mínimo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int EstoqueMinimo { get; set; }

        [Display(Name = "Estoque Ideal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int EstoqueIdeal { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public decimal PrecoVenda { get; set; }

        [Display(Name = "Fornecedores")]
        public List<ProdutoFornecedorViewModel> ProdutoFornecedores { get; set; }

        [Display(Name = "Id da Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerida.")]
        public Guid MarcaId { get; set; }

        [Display(Name = "Marca")]
        public MarcaViewModel Marca { get; set; }

        #region Index View Helpers
        public bool ItemEstoqueRazoavel
        {
            get
            {
                return Estoque < EstoqueIdeal && Estoque > EstoqueMinimo;
            }
        }

        public bool ItemEstoqueBaixo
        {
            get
            {
                return Estoque <= EstoqueMinimo;
            }
        }
        #endregion
    }
}
