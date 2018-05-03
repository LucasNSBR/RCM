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
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo razão social deve ter entre 10 e 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome fantasia deve ter entre 10 e 100 caracteres.")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "O campo descrição ter até 1000 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Documento")]
        public DocumentoViewModel Documento { get; set; }

        [Display(Name = "Contato")]
        public ContatoViewModel Contato { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }
    }
}
