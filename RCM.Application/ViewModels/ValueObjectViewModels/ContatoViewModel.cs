using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ValueObjectViewModels
{
    public class ContatoViewModel
    {
        [Display(Name = "Celular")]
        [StringLength(15, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Telefone Residencial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string TelefoneResidencial { get; set; }

        [Display(Name = "Telefone Comercial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O {0} deve ter até {1} caracteres.")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Observação")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string Observacao { get; set; }
    }
}