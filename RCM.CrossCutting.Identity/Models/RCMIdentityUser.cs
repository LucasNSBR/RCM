using Microsoft.AspNetCore.Identity;

namespace RCM.CrossCutting.Identity.Models
{
    public class RCMIdentityUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public RCMIdentityUser() { }

        public RCMIdentityUser(string email) : base(email)
        {
            Email = email;
        }

        public RCMIdentityUser(string firstName, string lastName, int age) 
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public RCMIdentityUser(string email, string firstName, string lastName, int age) : base(email)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
