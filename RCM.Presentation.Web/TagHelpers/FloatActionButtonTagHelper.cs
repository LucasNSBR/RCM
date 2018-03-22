using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RCM.Presentation.Web.TagHelpers
{
    public class FloatActionButtonTagHelper : TagHelper
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }

        public string ButtonWrapperClasses { get; set; } 
        public string IconName { get; set; } 
        public string IconClasses { get; set; } 
        public string AnchorClasses { get; set; }
        
        public FloatActionButtonTagHelper()
        {
            Action = Action ?? "Create";
            Controller = Controller ?? "Default";
            Area = Area ?? "Platform";
            ButtonWrapperClasses = ButtonWrapperClasses ?? "fixed-action-btn";
            IconName = IconName ?? "add";
            IconClasses = IconClasses ?? "material-icons center";
            AnchorClasses = AnchorClasses ?? "btn-floating btn-large waves-effect purple";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.PreContent.AppendHtml($"<div class=\"{ButtonWrapperClasses}\">");
            output.PreContent.AppendHtml($"<a href=\"/{Area}/{Controller}/{Action}\" class=\"{AnchorClasses}\">");
            output.Content.AppendHtml($"<i class=\"{IconClasses}\">{IconName}</i>");
            output.PostContent.AppendHtml("</a>");
            output.PostContent.AppendHtml("</div>");
        }
    }
}
