using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCM.Application.ViewModels.EventViewModels
{
    public class NormalizedEventViewModel
    {
        [Display(Name = "Id do Evento")]
        public Guid Id { get; set; }

        [Display(Name = "Id do Objeto Raiz")]
        public Guid AggregateId { get; set; }

        [Display(Name = "Tipo de Evento")]
        public string Type { get; set; }

        [Display(Name = "Data da Criação")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Argumentos")]
        public Dictionary<string, object> Args { get; set; }
    }
}
