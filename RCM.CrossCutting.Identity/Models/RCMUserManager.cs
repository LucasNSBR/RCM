using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMUserManager : UserManager<RCMIdentityUser>
    {
        public RCMUserManager(IUserStore<RCMIdentityUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<RCMIdentityUser> passwordHasher, IEnumerable<IUserValidator<RCMIdentityUser>> userValidators, IEnumerable<IPasswordValidator<RCMIdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<RCMIdentityUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {   
        }
    }
}
