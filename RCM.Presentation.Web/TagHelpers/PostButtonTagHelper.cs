using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RCM.Presentation.Web.TagHelpers
{
    public class PostButtonTagHelper : TagHelper
    {
        public string IconName { get; set; }
        public string IconClasses { get; set; } 
        public string ButtonClasses { get; set; } 

        public PostButtonTagHelper()
        {
            IconName = IconName ?? "done";
            IconClasses = IconClasses ?? "material-icons left";
            ButtonClasses = ButtonClasses ?? "btn waves-effect purple";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("class", $"{ButtonClasses}");
            output.PreContent.AppendHtml($"<i class=\"{IconClasses}\">{IconName}</i>");
        }
    }
}
