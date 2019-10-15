using CompetentieTool.Areas.Identity.Pages.Account;
using CompetentieTool.Data;
using CompetentieTool.Domain;
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
            
            
            if (await userManager.FindByNameAsync("thomass123") == null)
            {
                var user = new Sollicitant();
                var input = new RegisterSollicitantModel.InputModel();
                input.Achternaam = "Schuddinck";
                input.Voornaam = "Thomas";
                input.Email = "thomas@test.be";
                input.GsmNummer = "0491449500";
                input.Geslacht = "M";
                input.Huisnummer = "20";
                input.Straat = "Beekstraat";
                input.Nationaliteit = "Belg";
                input.Geboortedatum = new DateTime(1997, 12, 20);
                input.Gemeente = "Lokeren";
                input.Postcode = "9160";
                input.Opleiding = "Toegepaste Informatica";
                input.Opleidingsniveau = Models.Opleidingsniveau.Professionele_Bachelor;

                user.SetGegevensSollicitant(input);

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
                var user1 = new Organisatie();
                var input1 = new RegisterModel.InputModel();
                input1.Achternaam = "bobbie";
                input1.Voornaam = "Bob";
                input1.Email = "test@test.be";
                input1.GsmNummer = "0123456789";
                input1.Geslacht = "V";
                input1.Huisnummer = "20";
                input1.Straat = "koekusstraat";
                input1.Nationaliteit = "Belg";
                input1.Geboortedatum = new DateTime(1990, 12, 10);
                input1.Gemeente = "Gent";
                input1.Postcode = "9000";
                input1.OrganisatieNaam = "Coca-Cola";
                input1.Btwnummer = "0123456789";
                user1.SetGegevensWerkgever(input1);

                var result = await userManager.CreateAsync(user1);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user1, password);
                    await userManager.AddToRoleAsync(user1, role2);
                }
                id2  = user1.Id;
            }

            // use this to initialize vacature test data
             AddVacatures(context);
        }

        public static void AddVacatures(ApplicationDbContext context)
        {
            Vacature vac1 = new Vacature { Beschrijving = "Verpleger voor thuiszorg bij het gele kruis", Functie = "Verpleger voor thuiszorg" };
            Vacature vac2 = new Vacature { Beschrijving = "Verpleger in ziekenhuis UZ te Gent", Functie = "Verpleger" };
            Vacature vac3 = new Vacature { Beschrijving = "medewerker die helpt bij bloedinzamelingen", Functie = "Rode kruis medewerker" };




            Competentie comp1 = new Competentie { Naam = "Niet veroordelen", Verklaring = "De hulpverlener veroordeelt niet en is zich hierbij bewust van de invloed van zijn eigen waarde, opvoedings- en normenkader op zijn denken" };
            Competentie comp2 = new Competentie { Naam = "Situationeel denken", Verklaring = "De hulpverlener kan een inschatting maken wanneer een interventie al dan niet noodzakelijk is binnen het hulpverleningstrauct en beroept zich hiervoor op geïnternaliseerde ethisch en theoretische kaders." };
            Competentie comp3 = new Competentie { Naam = "Respecteren Zelfbeschikkingsrecht", Verklaring = "De hulpverlener respecteert het recht van de cliënt om zelf te beslissen  over zijn/haar situatie, ook al wijkt de beslissing af van de visie van de hulpverlener. Interventies die gericht zijn op het “overnemen” van de situatie bespreekt hij op voorhand met de cliënt zelf." };
            Competentie comp4 = new Competentie { Naam = "Omgaan met tegenoverdracht", Verklaring = "De hulpverlener is zich bewust van gevoelens van tegenoverdracht.  Hij/zij is in staat om te reflecteren van waaruit dit zou komt en kan dit bespreekbaar stellen." };

                       


            

            Vignet vignet1 = new Vignet { Beschrijving = "Boris woont alleen in een uitgewoonde studio in een verpauperde buurt van de gemeente. Na een residentiële opname van drie maanden werd hij  aangemeld voor mobiele psychiatrische zorg zodat jij zijn opvolging doet sinds een aantal weken. De begeleiding loopt in jouw opinie wat stroever, Boris heeft het vooral over praktische zaken die in orde zouden moeten gebracht worden.Boris heeft een zoon van 17 en een dochter van 12 waar hij het vaak over heeft, maar hij ziet hen relatief weinig.Enkele maanden geleden had Boris het over het feit dat hij het zeer jammer vindt dat hij voor de feestdagen geen geschenku voor zijn kinderen kan kopen. u brengt dit ter sprake bij de bewindvoerder die begin december 300 euro extra voorziet op zijn wekelijks bedrag van 100 euro.Bij jouw volgende huisbezoek zie u dat Boris een nieuwe smartphone heeft met een driedubbele camera." };
            Mogelijkheid optie11 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan over het feit dat U het jammer vindt dat hij het zorgsysteem misbruikt heeft" };
            Mogelijkheid optie12 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan over het feit dat hij uw vertrouwen misbruikt heeft" };
            Mogelijkheid optie13 = new Mogelijkheid { Beschrijving = "U spreekt Boris aan en wijst hem op zijn verantwoordelijkheid als vader." };
            Mogelijkheid optie14 = new Mogelijkheid { Beschrijving = "U onderneemt niks" };
            IList<Mogelijkheid> opties1 = new List<Mogelijkheid>();
            opties1.Add(optie11);
            opties1.Add(optie12);
            opties1.Add(optie13);
            opties1.Add(optie14);

            Vignet vignet2 = new Vignet { Beschrijving = "Een cliënt geeft aan dat hij naar Thailand op reis wil gaan. Gezien zijn instabiele psychotische problematiek en risico tot herval in middelengebruik vindt U dit geen goed idee." };
            Mogelijkheid optie21 = new Mogelijkheid { Beschrijving = "interveniëren via derden (bv. psychiater) om het reisplan af te laten lassen omwille van de risico’s." };
            Mogelijkheid optie22 = new Mogelijkheid { Beschrijving = "niks, dit is zijn individuele keuze en die moet gerespecteerd worden ongeacht de risico’s" };
            Mogelijkheid optie23 = new Mogelijkheid { Beschrijving = "proberen door gesprek zelfreflectie te stimuleren om toch het idee tot reizen te proberen veranderen" };
            Mogelijkheid optie24 = new Mogelijkheid { Beschrijving = "adviseren om niet te reizen gezien de risico’s die hieraan verbonden zijn." };
            IList<Mogelijkheid> opties2 = new List<Mogelijkheid>();
            opties2.Add(optie21);
            opties2.Add(optie22);
            opties2.Add(optie23);
            opties2.Add(optie24);

            Mogelijkheid optie31 = new Mogelijkheid { Beschrijving = "ik ga voor mezelf op zoek naar de reden" };
            Mogelijkheid optie32 = new Mogelijkheid { Beschrijving = "ik contacteer  een collega om mijn gevoel te bespreken" };
            Mogelijkheid optie33 = new Mogelijkheid { Beschrijving = "ik maak dit bespreekbaar bij  de cliënt" };
            Mogelijkheid optie34 = new Mogelijkheid { Beschrijving = "ik contacteer mijn  leidinggevende om tot een oplossing te komen" };
            Mogelijkheid optie35 = new Mogelijkheid { Beschrijving = "ik onderneem  stappen om de relatie van mijn kant te proberen verbeteren" };
            IList<Mogelijkheid> opties3 = new List<Mogelijkheid>();
            opties3.Add(optie31);
            opties3.Add(optie32);
            opties3.Add(optie33);
            opties3.Add(optie34);
            opties3.Add(optie35);




            IVraag vraag1 = new VraagCasus { VraagStelling = "Welke actie onderneemt U?", Vignet = vignet1, Opties = opties1, Competentie = comp1 };
            comp1.Vraag = vraag1;
            IVraag vraag2 = new VraagOpen { VraagStelling = "Verklaar waarom u dit zou doen", Competentie = comp2 };
            comp2.Vraag = vraag2;
            IVraag vraag3 = new VraagCasus { VraagStelling = "Wat doet U?", Vignet = vignet2, Opties = opties2, Competentie = comp3 };
            comp3.Vraag = vraag3;
            IVraag vraag4 = new VraagCasus { VraagStelling = "Je komt bij een nieuwe cliënt aan huis waar je bijna onmiddellijk een antipathie voor voelt. Dit gevoel blijft ook na de volgende bezoeken aanwezig. Wat doet u?", Opties = opties3, Vignet = vignet1,  Competentie = comp4 };
            comp4.Vraag = vraag4;




            ICollection<Competentie> competenties = new List<Competentie>();
            competenties.Add(comp1);
            //competenties.Add(comp2);
            competenties.Add(comp3);
            competenties.Add(comp4);

            vac1.AddCompetenties(competenties);
            vac3.AddCompetenties(competenties);

            context.Competenties.Add(comp1);
            context.Competenties.Add(comp2);

            context.Vacature.Add(vac1);
            context.Vacature.Add(vac2);
            context.Vacature.Add(vac3);

            context.SaveChanges();
        }
    }
}