using RCM.Application.ViewModels.ChequeViewModels;
using RCM.Application.ViewModels.ValueObjectViewModels;
using RCM.Domain.Models.ClienteModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Tipo de Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public ClienteTipoEnum Tipo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "A {0} deve ter até 1000 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Classificação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        public ClientePontuacaoEnum Pontuacao { get; set; }

        [Display(Name = "Contato")]
        public ContatoViewModel Contato { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }

        [Display(Name = "Documento")]
        public DocumentoViewModel Documento { get; set; }

        [Display(Name = "Cheques")]
        public List<ChequeViewModel> Cheques { get; set; }
    }
}