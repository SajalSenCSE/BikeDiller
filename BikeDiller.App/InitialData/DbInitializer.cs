using BikeDiller.App.Helpers;
using BikeDiller.DataBase;
using BikeDiller.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.InitialData
{
    public class DbInitializer : IDbInitialzer
    {
        private readonly BikeDillerDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(BikeDillerDbContext db, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager
            )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            //If have any pending migration
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }

            //if have any role
            if (_db.Roles.Any(r => r.Name == Helpers.Roles.Admin))
                return;

            //create role
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            }, "Sajalcse007$"
            ).GetAwaiter().GetResult();
            //assign role to admin user

            ///it will work but 1 time brack execution then it properly worrd working with this problem

            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Admin"), Roles.Admin);

            
        }
    }
}
