using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo nome deve ter entre 10 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo descrição é requerido.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo descrição deve ter entre 10 e 100 caracteres.")]
        public string Descricao { get; set; }

        public ICollection<ContatoViewModel> Contatos { get; set; }
        public ICollection<EnderecoViewModel> Enderecos { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}