using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RCM.Presentation.Web.Filters
{
    /// <summary>
    /// Redirect user to a valid path if access a anonymous action if already authenticated
    /// </summary>
    public class UnallowAuthorized : ActionFilterAttribute, IActionFilter
    {
        public string RedirectActionName { get; set; } 
        public string RedirectControllerName { get; set; }
        public string RedirectAreaName { get; set; }

        public UnallowAuthorized()
        {
            RedirectActionName = RedirectActionName ?? "Index";
            RedirectControllerName = RedirectControllerName ?? "Home";
            RedirectAreaName = RedirectAreaName ?? "Platform";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToActionResult(RedirectActionName, RedirectControllerName, new { area = RedirectAreaName });
        }
    }
}
