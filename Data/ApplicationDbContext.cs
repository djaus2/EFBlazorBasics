using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFBlazorBasics.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Activity> Activitys { get; set; }
        //public DbSet<Helper> Helpers { get; set; }
        //public DbSet<Round> Rounds { get; set; }

    }
}
