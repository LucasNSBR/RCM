using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class BancoViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Id é requerido.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo código de compensação é requerido.")]
        [StringLength(0, MinimumLength = 4, ErrorMessage = "O campo de código de compensação deve até 4 caracteres.")]
        public int CodigoCompensacao { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo nome deve ter entre 4 e 50 caracteres.")]
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
