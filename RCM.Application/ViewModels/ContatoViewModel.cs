using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Contato")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo contato é requerido.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo deve ter entre 5 e 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Observações")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "O campo observação deve ter até 1000 caracteres.")]
        public string Observacao { get; set; }

        [Display(Name = "Id do Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O cliente relacionado é requerido.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }
    }
}