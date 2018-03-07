using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMUserValidator : UserValidator<RCMIdentityUser>, IUserValidator<RCMIdentityUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<RCMIdentityUser> manager, RCMIdentityUser user)
        {
            return base.ValidateAsync(manager, user);
        }
    }
}
