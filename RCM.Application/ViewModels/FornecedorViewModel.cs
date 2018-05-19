using RCM.Application.ViewModels.ValueObjectViewModels;
using RCM.Domain.Models.FornecedorModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Tipo de Fornecedor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public FornecedorTipoEnum Tipo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Contato")]
        public ContatoViewModel Contato { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }

        [Display(Name = "Documento")]
        public DocumentoViewModel Documento { get; set; }

        [Display(Name = "Duplicatas")]
        public List<DuplicataViewModel> Duplicatas { get; set; }

        [Display(Name = "Notas Fiscais")]
        public List<NotaFiscalViewModel> NotasFiscais { get; set; }
    }
}