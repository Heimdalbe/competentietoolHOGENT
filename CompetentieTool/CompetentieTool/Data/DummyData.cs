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
                input.Username = "thomass123";
                input.GsmNummer = "0491449500";
                input.Geslacht = "man";
                input.Huisnummer = "20";
                input.Straat = "Beekstraat";
                input.Nationaliteit = "Belg";
                input.Geboortedatum = new DateTime(1997, 12, 20);
                input.Gemeente = "Lokeren";
                input.Postcode = "9160";

                user.SetGegevens(input);

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, "broek123");
                    await userManager.AddToRoleAsync(user, role1);
                }
                id1 = user.Id;
            }
            if (await userManager.FindByNameAsync("testerboy420") == null)
            {
                var user = new ApplicationUser();
                var input = new RegisterModel.InputModel();
                input.Achternaam = "bobbie";
                input.Voornaam = "Bob";
                input.Email = "test@test.be";
                input.Username = "testerboy420";
                input.GsmNummer = "0123456789";
                input.Geslacht = "man";
                input.Huisnummer = "20";
                input.Straat = "koekjesstraat";
                input.Nationaliteit = "Belg";
                input.Geboortedatum = new DateTime(1990, 12, 10);
                input.Gemeente = "Gent";
                input.Postcode = "9000";
                
                user.SetGegevens(input);

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