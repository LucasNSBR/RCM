using RCM.Application.ViewModels.ChequeViewModels;
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

        [Display(Name = "Cheques")]
        public List<ChequeViewModel> Cheques { get; set; }

        #region Documento
        [Display(Name = "CPF/CNPJ")]
        [StringLength(14, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string DocumentoCadastroNacional { get; set; }

        [Display(Name = "RG/Inscrição Estadual")]
        [StringLength(14, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string DocumentoCadastroEstadual { get; set; }
        #endregion

        #region Contato
        [Display(Name = "Celular")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string ContatoCelular { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string ContatoEmail { get; set; }

        [Display(Name = "Telefone Residencial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string ContatoTelefoneResidencial { get; set; }

        [Display(Name = "Telefone Comercial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string ContatoTelefoneComercial { get; set; }

        [Display(Name = "Observação")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ContatoObservacao { get; set; }
        #endregion

        #region Endereco
        [Display(Name = "Rua")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string EnderecoRua { get; set; }

        [Display(Name = "Número")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int EnderecoNumero { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string EnderecoBairro { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string EnderecoComplemento { get; set; }

        [Display(Name = "Id da Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        public Guid EnderecoCidadeId { get; set; }

        [Display(Name = "Cidade")]
        public CidadeViewModel EnderecoCidade { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 0, ErrorMessage = "O {0} deve ter {2} e {1} caracteres.")]
        public string EnderecoCEP { get; set; }
        #endregion
    }
}