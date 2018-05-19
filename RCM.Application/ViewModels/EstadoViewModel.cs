using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; private set; }

        [Display(Name = "Sigla")]
        public string Sigla { get; private set; }

        [Display(Name = "Nome")]
        public string Nome { get; private set; }

        [Display(Name = "Cidades")]
        public List<CidadeViewModel> Cidades { get; private set; }
    }
}