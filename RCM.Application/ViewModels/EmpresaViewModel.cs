using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EmpresaViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }

        [Display(Name = "Razão Social")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "A {0} ter até {1} caracteres.")]
        public string Descricao { get; set; }

        #region Documento
        [Display(Name = "CNPJ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O {0} deve ter {1} caracteres.")]
        public string DocumentoCadastroNacional { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "O {0} deve ter {1} caracteres.")]
        public string DocumentoCadastroEstadual { get; set; }
        #endregion

        #region Contato
        [Display(Name = "Celular")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string ContatoCelular { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(100, MinimumLength = 15, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string ContatoEmail { get; set; }

        [Display(Name = "Telefone Residencial")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string ContatoTelefoneResidencial { get; set; }

        [Display(Name = "Telefone Comercial")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string ContatoTelefoneComercial { get; set; }

        [Display(Name = "Observação")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string ContatoObservacao { get; set; }
        #endregion

        #region Endereco
        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string EnderecoRua { get; set; }

        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int EnderecoNumero { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O {0} deve ter {1} caracteres.")]
        public string EnderecoCEP { get; set; }
        #endregion
    }
}
