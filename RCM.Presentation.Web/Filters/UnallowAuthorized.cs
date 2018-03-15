using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RCM.Presentation.Web.Filters
{
    public class UnallowAuthorized : ActionFilterAttribute, IActionFilter
    {
        public string RedirectActionName { get; set; } = "Index";
        public string RedirectControllerName { get; set; } = "Duplicatas";
        public string RedirectAreaName { get; set; } = "Platform"; 

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToActionResult(RedirectActionName, RedirectControllerName, new { area = RedirectAreaName });
        }
    }
}
