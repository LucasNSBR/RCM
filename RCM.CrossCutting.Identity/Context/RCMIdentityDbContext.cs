using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RCM.CrossCutting.Identity.Models;
using System.IO;

namespace RCM.CrossCutting.Identity.Context
{
    public class RCMIdentityDbContext : IdentityDbContext<RCMIdentityUser, RCMIdentityRole, int>
    {
        public RCMIdentityDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("RCMDatabase"));
        }
    }
}
