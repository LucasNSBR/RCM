using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RCM.Presentation.Web.TagHelpers
{
    [HtmlTargetElement("action-button", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ActionButtonTagHelper : TagHelper
    {
        public string IconName { get; set; }
        public string IconDefaultClasses { get; set; } = "material-icons left";
        public string ButtonDefaultClasses { get; set; } = "btn waves-effect purple";
        public string AdditionalClasses { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            TagHelperAttribute actionAttr;
            output.Attributes.TryGetAttribute("asp-action", out actionAttr);
            TagHelperAttribute routeAttr;
            output.Attributes.TryGetAttribute("asp-route-id", out routeAttr);
            TagHelperAttribute controllerAttr;
            output.Attributes.TryGetAttribute("asp-controller", out controllerAttr);

            output.Attributes.Clear();
            output.Attributes.Add("href", $"/{controllerAttr.Value}/{actionAttr.Value}/{routeAttr.Value}");
            output.Attributes.Add("class", $"{ButtonDefaultClasses}");
            output.PreContent.AppendHtml($"<i class=\"{IconDefaultClasses}\">{IconName}</i>");
        }
    }
}
