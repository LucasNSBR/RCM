using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set;  }

        [Display(Name = "Id da Cidade")]
        public int CidadeId { get; set; }
        public CidadeViewModel Cidade { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}";
        }
    }
}