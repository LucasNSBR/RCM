using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewComponentsModels
{
    public class SearchBarViewModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Placeholder { get; set; }
        public Dictionary<string, string> SelectValues { get; set; }

        public SearchBarViewModel()
        {
            ActionName = "Index";
            Placeholder = "Pesquise algo...";
            SelectValues = new Dictionary<string, string>();
        }
    }
}
