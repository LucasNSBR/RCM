using System;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.ProdutoViewModels
{
    public class AplicacaoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Ano")]
        [Range(0, 2019, ErrorMessage = "O {0} deve estar em um formáto válido.")]
        public int CarroAno { get; set; }

        [Display(Name = "Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A {0} é requerida.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres.")]
        public string CarroMarca { get; set; }

        [Display(Name = "Modelo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} é requerido.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        public string CarroModelo { get; set; }

        [Display(Name = "Motor")]
        [StringLength(100, ErrorMessage = "O {0} deve até {1} caracteres.")]
        public string CarroMotor { get; set; }

        [Display(Name = "Observação")]
        [StringLength(1000, ErrorMessage = "A {0} deve ter até {1} caracteres.")]
        public string Observacao { get; set; }

        [Display(Name = "Id do Produto")]
        public Guid ProdutoId { get; set; }
    }
}
