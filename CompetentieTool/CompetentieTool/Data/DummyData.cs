using CompetentieTool.Areas.Identity.Pages.Account;
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
            
            
            if (await userManager.FindByNameAsync("thomass123") == null)
            {
                var user = new ApplicationUser();
                var input = new RegisterModel.InputModel();
                input.Achternaam = "Schuddinck";
                input.Voornaam = "Thomas";
                input.Email = "thomas@test.be";
                input.GsmNummer = "0491449500";
                input.Geslacht = "man";
                input.Huisnummer = "20";
                input.Straat = "Beekstraat";
                input.Nationaliteit = "Belg";
                input.Geboortedatum = new DateTime(1997, 12, 20);
                input.Gemeente = "Lokeren";
                input.Postcode = "9160";

                user.SetGegevensWerkgever(input);

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, "Thomas1!");
                    await userManager.AddToRoleAsync(user, role1);
                }
                id1 = user.Id;
            }
            if (await userManager.FindByNameAsync("testerboy420") == null)
            {
                var user1 = new ApplicationUser();
                var input1 = new RegisterModel.InputModel();
                input1.Achternaam = "bobbie";
                input1.Voornaam = "Bob";
                input1.Email = "test@test.be";
                input1.GsmNummer = "0123456789";
                input1.Geslacht = "man";
                input1.Huisnummer = "20";
                input1.Straat = "koekjesstraat";
                input1.Nationaliteit = "Belg";
                input1.Geboortedatum = new DateTime(1990, 12, 10);
                input1.Gemeente = "Gent";
                input1.Postcode = "9000";
                
                user1.SetGegevensWerkgever(input1);

                var result = await userManager.CreateAsync(user1);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user1, password);
                    await userManager.AddToRoleAsync(user1, role1);
                }
                id2  = user1.Id;
            }
        }
    }
}