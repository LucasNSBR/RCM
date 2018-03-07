using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMSignInManager : SignInManager<RCMIdentityUser>
    {
        public RCMSignInManager(RCMUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<RCMIdentityUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<RCMIdentityUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }
}
