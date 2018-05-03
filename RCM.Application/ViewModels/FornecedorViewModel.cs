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
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Observações")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "O campo observação deve ter até 1000 caracteres.")]
        public string Observacao { get; set; }

        [Display(Name = "Documento")]
        public DocumentoViewModel Documento { get; set; }

        [Display(Name = "Contato")]
        public ContatoViewModel Contato { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoViewModel Endereco { get; set; }

        [Display(Name = "Duplicatas")]
        public List<DuplicataViewModel> Duplicatas { get; set; }

        [Display(Name = "Notas Fiscais")]
        public List<NotaFiscalViewModel> NotasFiscais { get; set; }
    }
}