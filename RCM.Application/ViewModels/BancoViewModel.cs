using RCM.Application.ViewModels.ChequeViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        
        [Display(Name = "Código de Compensação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [Range(0, 9999, ErrorMessage = "O {0} deve estar em um formato válido.")]
        public int CodigoCompensacao { get; set; }
        
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }
        
        [Display(Name = "Cheques")]
        public List<ChequeViewModel> Cheques { get; set; }

        [Display(Name = "Quantidade de Cheques")]
        public int QuantidadeCheques
        {
            get
            {
                return Cheques?.Count ?? 0;
            }
        }
    }
}
