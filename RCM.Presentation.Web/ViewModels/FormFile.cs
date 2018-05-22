using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RCM.Presentation.Web.ViewModels
{
    public class FormFile
    {
        [Display(Name = "Arquivo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O arquivo é requerido.")]
        public IFormFile File { get; set; }
    }
}
