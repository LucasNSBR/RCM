using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewComponentsModels
{
    public class SearchBarViewModel
    {
        public string Placeholder { get; set; }
        public Dictionary<string, string> SelectValues { get; set; }

        public SearchBarViewModel()
        {
            Placeholder = "Pesquise algo...";
            SelectValues = new Dictionary<string, string>();
        }
    }
}
