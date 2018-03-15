using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RCM.CrossCutting.Identity.Context;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMUserStore : UserStore<RCMIdentityUser, RCMIdentityRole, RCMIdentityDbContext, int>, IUserStore<RCMIdentityUser>
    {
        public RCMUserStore(RCMIdentityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}