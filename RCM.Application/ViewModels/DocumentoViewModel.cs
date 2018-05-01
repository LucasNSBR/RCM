using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class DocumentoViewModel
    { 
        [Display(Name = "CPF/CNPJ")]
        public string CadastroNacional { get; set; }
        [Display(Name = "RG/Inscrição Estadual")]
        public string CadastroEstadual { get; set; }
    }
}
