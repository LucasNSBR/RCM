using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IdentityResult> ChangeBasicInfoAsync(RCMIdentityUser user, string firstName, string lastName, int age)
        {
            var exists = await Store.FindByIdAsync(user.Id.ToString(), CancellationToken);
            if (exists == null)
                return IdentityResult.Failed(new IdentityError() { Description = "User not found" });

            user.FirstName = firstName ?? user.FirstName;
            user.LastName = lastName ?? user.LastName;
            user.Age = age;

            return await UpdateAsync(user);
        }
    }
}
