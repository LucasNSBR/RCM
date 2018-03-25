using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RCM.Presentation.Web.TagHelpers
{
    public class ActionButtonTagHelper : TagHelper
    {
        public string IconName { get; set; }
        public string IconDefaultClasses { get; set; } 
        public string ButtonDefaultClasses { get; set; } 

        public ActionButtonTagHelper()
        {
            IconName = IconName ?? "edit";
            IconDefaultClasses = IconDefaultClasses ?? "material-icons left";
            ButtonDefaultClasses = ButtonDefaultClasses ?? "btn waves-effect purple";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            TagHelperAttribute actionAttr;
            output.Attributes.TryGetAttribute("asp-action", out actionAttr);
            TagHelperAttribute routeAttr;
            output.Attributes.TryGetAttribute("asp-route-id", out routeAttr);
            TagHelperAttribute controllerAttr;
            output.Attributes.TryGetAttribute("asp-controller", out controllerAttr);
            TagHelperAttribute areaAttr;
            output.Attributes.TryGetAttribute("asp-area", out areaAttr);

            output.Attributes.Clear();
            output.Attributes.Add("href", $"/{areaAttr.Value}/{controllerAttr.Value}/{actionAttr.Value}/{routeAttr?.Value ?? ""}");
            output.Attributes.Add("class", $"{ButtonDefaultClasses}");
            output.PreContent.AppendHtml($"<i class=\"{IconDefaultClasses}\">{IconName}</i>");
        }
    }
}
