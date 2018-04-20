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
        
        [Display(Name = "Código de compensação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo código de compensação é requerido.")]
        [Range(0, 9999, ErrorMessage = "O código de compensação deve ter entre 1 e 4 caracteres.")]
        public int CodigoCompensacao { get; set; }
        
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo nome deve ter entre 4 e 50 caracteres.")]
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
