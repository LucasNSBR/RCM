using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ContatoViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Contato")]
        public string Nome { get; set; }

        [Display(Name = "Observações")]
        public string Observacao { get; set; }

        [Display(Name = "Id do Cliente")]
        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}