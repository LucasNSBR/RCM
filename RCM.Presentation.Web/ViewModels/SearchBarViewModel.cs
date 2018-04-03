using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewModels
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
