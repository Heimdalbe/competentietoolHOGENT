﻿using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
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
                    Adres = "aa straat",
                    Gemeente = "aa stad",
                    Postcode = 1000
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
                    Adres = "bb straat",
                    Gemeente = "bb stad",
                    Postcode = 1000
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                id2  = user.Id;

                
            }
            //AddVacatures(context);
        }
        public static void AddVacatures(ApplicationDbContext context)
        {
            Competentie comp1 = new Competentie { Naam = "Niet veroordelen", Verklaring = "De hulpverlener veroordeelt niet en is zich hierbij bewust van de invloed van zijn eigen waarde, opvoedings- en normenkader op zijn denken" };
            Competentie comp2 = new Competentie { Naam = "Situationeel denken", Verklaring = "De hulpverlener kan een inschatting maken wanneer een interventie al dan niet noodzakelijk is binnen het hulpverleningstraject en beroept zich hiervoor op geïnternaliseerde ethisch en theoretische kaders." };

            Vacature vac1 = new Vacature { Beschrijving = "test er test", Functie = "hulpverlener" };
            Vacature vac2 = new Vacature { Beschrijving = "nog een test", Functie = "brandweer" };
            Vacature vac3 = new Vacature { Beschrijving = "test nr 3", Functie = "IT" };

            Vignet vignet = new Vignet { Beschrijving = "Boris woont alleen in een uitgewoonde studio in een verpauperde buurt van de gemeente. Na een residentiële opname van drie maanden werd hij  aangemeld voor mobiele psychiatrische zorg zodat jij zijn opvolging doet sinds een aantal weken. De begeleiding loopt in jouw opinie wat stroever, Boris heeft het vooral over praktische zaken die in orde zouden moeten gebracht worden.Boris heeft een zoon van 17 en een dochter van 12 waar hij het vaak over heeft, maar hij ziet hen relatief weinig.Enkele maanden geleden had Boris het over het feit dat hij het zeer jammer vindt dat hij voor de feestdagen geen geschenkje voor zijn kinderen kan kopen. Je brengt dit ter sprake bij de bewindvoerder die begin december 300 euro extra voorziet op zijn wekelijks bedrag van 100 euro.Bij jouw volgende huisbezoek zie je dat Boris een nieuwe smartphone heeft met een driedubbele camera." };
            Mogelijkheid optie1 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan over het feit dat U het jammer vindt dat hij het zorgsysteem misbruikt heeft" };
            Mogelijkheid optie2 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan over het feit dat hij uw vertrouwen misbruikt heeft" };
            Mogelijkheid optie3 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan en wijst hem op zijn verantwoordelijkheid als vader." };
            Mogelijkheid optie4 = new Mogelijkheid { Beschrijving = "U onderneemt niks" };
            IList<Mogelijkheid> opties1 = new List<Mogelijkheid>();
            opties1.Add(optie1);
            opties1.Add(optie2);
            opties1.Add(optie3);
            opties1.Add(optie4);

            IVraag vraag = new VraagCasus { VraagStelling = "Welke actie onderneemt U?", Vignet = vignet, Opties = opties1, Competentie = comp1};
            comp1.Vraag = vraag;

            IVraag vraag2 = new VraagOpen { VraagStelling = "Verklaar waarom u dit zou doen", Competentie = comp2 };

            comp2.Vraag = vraag2;

            ICollection<Competentie> competenties = new List<Competentie>();
            competenties.Add(comp1);
            competenties.Add(comp2);

            vac1.AddCompetentie(competenties);
            vac3.AddCompetentie(competenties);

            context.Vacatures.Add(vac1);
            context.Vacatures.Add(vac2);
            context.Vacatures.Add(vac3);

            context.Competenties.Add(comp1);
            context.Competenties.Add(comp2);

            context.SaveChanges();
        }
    }
}