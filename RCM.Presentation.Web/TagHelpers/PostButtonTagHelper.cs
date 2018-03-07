using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace RCM.Presentation.Web.TagHelpers
{
    [HtmlTargetElement("post-button", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PostButtonTagHelper : TagHelper
    {
        public string IconName { get; set; }
        public string IconDefaultClasses { get; set; } = "material-icons left";
        public string ButtonDefaultClasses { get; set; } = "btn waves-effect purple";
        public string AdditionalClasses { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("class", $"{ButtonDefaultClasses}");
            output.PreContent.AppendHtml($"<i class=\"{IconDefaultClasses}\">{IconName}</i>");
        }
    }
}
