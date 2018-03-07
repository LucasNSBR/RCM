using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMUserPasswordValidator : PasswordValidator<RCMIdentityUser>, IPasswordValidator<RCMIdentityUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<RCMIdentityUser> manager, RCMIdentityUser user, string password)
        {
            return base.ValidateAsync(manager, user, password);
        }
    }
}
