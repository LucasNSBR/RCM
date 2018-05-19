using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RCM.Presentation.Web.Filters
{
    /// <summary>
    /// Redirect user to a valid path if don't have a specific claim
    /// </summary>
    public class ClaimAuthorization : ActionFilterAttribute, IActionFilter
    {
        public string ClaimName { get; set; }

        public string RedirectActionName { get; set; }
        public string RedirectControllerName { get; set; }
        public string RedirectAreaName { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if(!user.HasClaim(c => c.Type == ClaimName))
                context.Result = new RedirectToActionResult(RedirectActionName, RedirectControllerName, new { area = RedirectAreaName });
        }
    }
}
