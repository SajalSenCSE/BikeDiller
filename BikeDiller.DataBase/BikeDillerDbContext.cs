using BikeDiller.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeDiller.DataBase
{
    public class BikeDillerDbContext:IdentityDbContext<IdentityUser>
    {
        public BikeDillerDbContext(DbContextOptions<BikeDillerDbContext> options):base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
