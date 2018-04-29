using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class ContatoViewModel
    {
        //Aggregate Root Id
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Celular")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo celular é requerido.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O campo deve ter entre 8 e 15 caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O campo deve ter até 100 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Telefone Residencial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O campo deve ter até 15 caracteres.")]
        public string TelefoneResidencial { get; set; }

        [Display(Name = "Telefone Comercial")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O campo deve ter até 15 caracteres.")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Observações")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "O campo deve ter até 250 caracteres.")]
        public string Observacao { get; set; }
    }
}