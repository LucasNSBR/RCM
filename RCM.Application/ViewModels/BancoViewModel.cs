using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class BancoViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo ID é requerido.")]
        public int Id { get; set; }

        public int CodigoCompensacao { get; set; }
        
  //      [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome do banco deve ter entre 4 e 50 caracteres e não pode estar vazio.")]
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
