using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RCM.Presentation.Web.TagHelpers
{
    public class FloatActionButtonTagHelper : TagHelper
    {
        public string ButtonWrapperClasses { get; set; } = "fixed-action-btn";
        public string ActionName { get; set; } = "Create";
        public string IconName { get; set; } = "add";
        public string IconClasses { get; set; } = "material-icons center";
        public string AnchorClasses { get; set; } = "btn-floating btn-large waves-effect purple";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperAttribute actionAttr;
            output.Attributes.TryGetAttribute("asp-action", out actionAttr);
            TagHelperAttribute controllerAttr;
            output.Attributes.TryGetAttribute("asp-controller", out controllerAttr);
            TagHelperAttribute areaAttr;
            output.Attributes.TryGetAttribute("asp-area", out areaAttr);

            output.TagName = "a";
            output.PreContent.AppendHtml($"<div class=\"{ButtonWrapperClasses}\">");
            output.PreContent.AppendHtml($"<a href=\"/{areaAttr.Value}/{controllerAttr.Value}/{actionAttr.Value}\" class=\"{AnchorClasses}\">");
            output.Content.AppendHtml($"<i class=\"{IconClasses}\">{IconName}</i>");
            output.PostContent.AppendHtml("</a>");
            output.PostContent.AppendHtml("</div>");
        }
    }
}
