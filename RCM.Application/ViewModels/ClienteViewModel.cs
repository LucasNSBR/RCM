using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Display(Name = "Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome deve ter entre 10 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo descrição é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo descrição deve ter entre 10 e 100 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Contatos")]
        public ICollection<ContatoViewModel> Contatos { get; set; }

        [Display(Name = "Endereços")]
        public ICollection<EnderecoViewModel> Enderecos { get; set; }

        [Display(Name = "Cheques")]
        public ICollection<ChequeViewModel> Cheques { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}