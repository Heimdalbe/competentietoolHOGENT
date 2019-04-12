using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<Models.Identities.ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string role1 = "Werkgever";
            string desc1 = "";
            string id1 = "";

            string role2 = "Sollicitant";
            string desc2 = "";
            string id2 = "";

            string password = "P@ssw00rd!!";

            if (await roleManager.FindByIdAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByIdAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await userManager.FindByNameAsync("aaa@aa.aa") == null)
            {
                var user = new Models.Identities.ApplicationUser
                {
                    UserName = "aaa@aa.aa",
                    Email = "aaa@aa.aa",
                    Voornaam = "aa",
                    Achternaam = "aa",
                    Straat = "aa straat",
                    Stad = "aa stad",
                    Postcode = "1000"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                id1 = user.Id;
            }
            if (await userManager.FindByNameAsync("bbb@bb.bb") == null)
            {
                var user = new Models.Identities.ApplicationUser
                {
                    UserName = "bbb@bb.bb",
                    Email = "bbb@bb.bb",
                    Voornaam = "bb",
                    Achternaam = "bb",
                    Straat = "bb straat",
                    Stad = "bb stad",
                    Postcode = "1000"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                id2  = user.Id;
            }
        }
    }
}