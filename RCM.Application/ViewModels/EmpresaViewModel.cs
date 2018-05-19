using RCM.Application.ViewModels.ValueObjectViewModels;
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

        [Display(Name = "Documento")]
        public DocumentoViewModel Documento { get; set; }

        [Display(Name = "Contato")]
        public ContatoViewModel Contato { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }
    }
}
