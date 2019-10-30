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
                    await userManager.AddToRoleAsync(user, role2);
                }
                id1 = user.Id;
            }
            var user1 = new Organisatie();
            if (await userManager.FindByNameAsync("testerboy420") == null)
            {
                
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
                    await userManager.AddToRoleAsync(user1, role1);
                }
                id2  = user1.Id;
            }
            var user2 = new Organisatie();
            if (await userManager.FindByNameAsync("testerboy420") == null)
            {

                var input1 = new RegisterModel.InputModel();
                input1.Achternaam = "bobbie";
                input1.Voornaam = "Bob";
                input1.Email = "test2@test.be";
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
                user2.SetGegevensWerkgever(input1);

                var result = await userManager.CreateAsync(user2);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user2, password);
                    await userManager.AddToRoleAsync(user2, role1);
                }
                id2 = user2.Id;
            }

            // use this to initialize vacature test data
            AddVacatures(context, user1, user2);
        }

        public static void AddVacatures(ApplicationDbContext context, ApplicationUser bedrijf, ApplicationUser bedrijf2)
        {
            Vacature vac1 = new Vacature { Beschrijving = "Verpleger voor thuiszorg bij het gele kruis", Functie = "Verpleger voor thuiszorg" };
            Vacature vac2 = new Vacature { Beschrijving = "Verpleger in ziekenhuis UZ te Gent", Functie = "Verpleger" };
            Vacature vac3 = new Vacature { Beschrijving = "Medewerker die helpt bij bloedinzamelingen", Functie = "Rode kruis medewerker" };

            //Vignets
            Vignet boris = new Vignet { Beschrijving = "Boris woont alleen in een uitgewoonde studio in een verpauperde buurt van de gemeente. Na een residentiële opname van drie maanden werd hij  aangemeld voor mobiele psychiatrische zorg zodat jij zijn opvolging doet sinds een aantal weken. De begeleiding loopt in jouw opinie wat stroever, Boris heeft het vooral over praktische zaken die in orde zouden moeten gebracht worden.Boris heeft een zoon van 17 en een dochter van 12 waar hij het vaak over heeft, maar hij ziet hen relatief weinig.Enkele maanden geleden had Boris het over het feit dat hij het zeer jammer vindt dat hij voor de feestdagen geen geschenku voor zijn kinderen kan kopen. u brengt dit ter sprake bij de bewindvoerder die begin december 300 euro extra voorziet op zijn wekelijks bedrag van 100 euro.Bij jouw volgende huisbezoek zie u dat Boris een nieuwe smartphone heeft met een driedubbele camera." };
            Vignet vignet2 = new Vignet { Beschrijving = "Een cliënt geeft aan dat hij naar Thailand op reis wil gaan. Gezien zijn instabiele psychotische problematiek en risico tot herval in middelengebruik vindt U dit geen goed idee." };
            Vignet kamiel = new Vignet { Beschrijving = "Kamiel is een 65 jarige man die reeds jarenlang drinkt en opgevolgd wordt door straathoekwerk en het mobiel team. De laatste jaren drinkt Kamiel continue, maar weigert hierin iets te veranderen. De bezoeken worden gekenmerkt door vrij korte gesprekken waar Kamiel steevast begint te vloeken op het OCMW en het feit dat hij “kort wordt gezet”. Gezien meerdere vechtpartijen onder invloed in de gang van zijn woonunit wordt hij deze week uit zijn woonst gezet. De psychiater heeft beslist dat de opvolging door het mobiele team niet kan gecontinueerd worden omdat er geen vraag tot verandering is, opvolging via straathoekwerk wordt voorzien en de nieuwe domicilie(adres OCMW) niet meer in het regionale werkingsgebied ligt van de mobiele team." };
            Vignet anna = new Vignet { Beschrijving = "Anna heeft steeds samen met haar man in een bakkerij gewerkt. De laatste jaren vertoonde Anna steeds meer tekenen van depressie en steeg haar alcoholgebruik. Na een desastreuze escalatie werd ze opgenomen onder een gedwongen statuut. Haar man verliet haar tijdens de drie maanden durende gedwongen opname.Hierna verbleef Anna nog 9 maanden vanuit vrijwillig statuut in een residentiële setting voor mensen met stemmingsschommelingen. Anna werd twee maanden geleden getransfereerd naar beschut wonen.Ze keek hier enorm naar uit, het zou immers de eerste keer zijn dat ze op eigen benen ging staan los van het juk van haar man. Bovendien heeft ze net een functie als vrijwilliger in de kringloopwinkel gekregen. Toen u deze week de bewonersvergadering ging begeleiden was Anne niet op het overleg.U vond haar terug in bed. Vandaag gaat u terug een kijkje nemen in het huis.In plaats van op de plaats waar ze vrijwilligerswerk doet treft u Anna opnieuw terug in bed aan.Ze geeft aan dat het voor haar allemaal niet meer hoeft en dat ze er het liefst een einde aan wil maken." };
            Vignet thomas = new Vignet { Beschrijving = "Thomas heeft een lang parcours achter de rug van alcoholafhankelijkheid. u hebt Thomas leren kennen op het moment dat hij \"zijn leven aan het beteren was\", zoals één van uw collega’s het benoemde. Alles lijkt er inderdaad op te wijzen dat Thomas zijn alcoholprobleem onder controle heeft. De laatste weken hebt u echter het gevoel dat er minder openheid is in de gesprekken dan voorheen. Thomas vertelt vooral over dagelijkse gebeurtenissen en herhaalt hoe goed hij wel bezig is in het leven en hoe blij hij is met de vooruitgang die hij boekt. Hij ziet er nochtans wat \"verwaaider\" uit dan dat u de laatste tijd gewoon bent. Tijdens het huisbezoek passeert u langs de keuken en zietu een bijna lege portofles op de tafel staan, half weggemoffeld onder een keukenhanddoek. De volgende dag vindt een netwerkoverleg plaats waar huisarts, psycholoog, OCMW - dienst etc.rond de tafel zitten. Thomas mocht aansluiten op dit overleg, maar gaf aan dit liever niet te willen. Het onderwerp van het netwerkoverleg is de werkhervatting. Alle aanwezigen zijn zich uitermate lovend over het parcours dat Thomas volgt en pleiten voor een werkoriëntatie naar taxichauffeur." };
            Vignet murat = new Vignet { Beschrijving = "U begeleidt in het mobiele crisisteam Murat, een man van 21 jaar die drie jaar geleden na een helse tocht uit Eritrea in Vlaanderen is terecht gekomen als politiek vluchteling. Hij spreekt al behoorlijk goed Nederlands en woont in een kleine studio in de stad. Murat blijkt erg angstig waarbij het verhaal dat hij vergiftigd zal worden op de voorgrond staat. De psychiater weet niet goed wat er precies aan de hand is en hij start uit voorzorg met een generisch antipsychoticum wegens vermoeden van psychotische problematiek. U gaat met uw collega twee keer per week op bezoek. Telkens blijft Murat vertellen over het gevoel dat hij achtervolgd wordt, hij vermagert zienderogen .Het laatste bezoek is van korte duur. Hoewel hij jullie beleefd ontvangt, stelt hij nogal kordaat dat \"het nu al lang genoeg heeft geduurd\". Hij weigert om zijn medicatie nog te nemen en wil evenmin nog geholpen worden door jullie. Het valt jou in het algemeen op dat er in het mobiele crisisteam steeds meer aanmeldingen komen van politiek vluchtelingen met psychische problemen. U weet zelf niet zo goed hoe u met deze problematiek moet omgaan." };
            Vignet jozefien = new Vignet { Beschrijving = "U doet nu al een paar weken de begeleiding van Jozefien, een 30-jarige alleenstaande vrouw met twee kinderen, Emiel van drie jaar en Suzanne van vijf jaar. Jozefien belandde in een postnatale depressie na de geboorte van Emiel maar is hier nooit echt helemaal van hersteld. Ze onderging haar zorgtraject tot nu toe als een voorbeeldige cliënt, maar op haar laatste bezoek stelt ze na een lange stilte in het gesprek dat ze tot het besluit moet komen dat de tweewekelijkse bezoeken van het mobiele team wel gezellig zijn, maar haar situatie eigenlijk niet veel verandert." };
            Vignet kurt = new Vignet { Beschrijving = "Kurt is een 65-jarige man die haast levenslang met een ernstige psychotische problematiek kampt en daarnaast ook een fysische beperking aan zijn linkerarm opliep na een aanrijding met een wagen nu ongeveer vijf jaar geleden. Kurt heeft geen directe familie meer in leven en heeft met verre familieleden al decennia geen contact meer. Wel heeft hij nog een paar vrienden waarmee hij geregeld kaart speelt. Op de afdeling waar hij verblijft heeft hij een vriendin die rolstoelafhankelijk is. Graag zouden beiden samen gaan wonen. Kurt heeft al enkele keren een aanvraag ingediend maar deze werd nooit goedgekeurd door het team. Nu heeft hij zelf via een medepatiënt een appartement gevonden waar hij en zijn vriendin zouden kunnen intrekken. Graag zou hij ook meubels kopen voor dit appartement. Hij heeft hier echter beperkte middelen toe gezien zijn bescheiden inkomen." };
            Vignet team = new Vignet { Beschrijving = "U werkt reeds enkele maanden in een team en volgt een cliënt op met een persoonlijkheidsproblematiek. Gezien u het gevoel hebt dat de cliënte zeer appellerend is naar u beperkt u de contacten tot het afgesproken 1 bezoek/week. Dit weekend heeft de cliënte een collega die van dienst was opgebeld omwille van een vermeende crisis. De collega nam dit ernstig en brengt maandag op het teamoverleg met veel detail waarom zij vindt dat een dagelijkse opvolging te verantwoorden valt. Door de manier waarop uw collega dit brengt hebt u het gevoel dat uw competentie in deze situatie in twijfel wordt getrokken. Zelf ziet u in deze situatie een mogelijke manier tot splitting vanuit de cliënt." };

            // COMPETENTIES
            // vragen multiple choice zonder score

            // comp 1
            Competentie comp1 = new Competentie
            {
                Naam = "Niet veroordelen",
                Verklaring = "De hulpverlener veroordeelt niet en is zich hierbij bewust van de invloed van zijn eigen waarde, opvoedings- en normenkader op zijn denken"
            };

            Mogelijkheid optie11 = new Mogelijkheid { Input = "U spreekt Boris aan over het feit dat U het jammer vindt dat hij het zorgsysteem misbruikt heeft", Output = "de cliënt aanspreekt over zijn/haar gedrag" };
            Mogelijkheid optie12 = new Mogelijkheid { Input = "U spreekt Boris aan over het feit dat hij uw vertrouwen misbruikt heeft", Output = "de cliënt aanspreekt over zijn/haar gevoel hierbij" };
            Mogelijkheid optie13 = new Mogelijkheid { Input = "U spreekt Boris aan en wijst hem op zijn verantwoordelijkheid als vader.", Output = "de cliënt aanspreekt over zijn verantwoordelijkheid als vader" };
            Mogelijkheid optie14 = new Mogelijkheid { Input = "U onderneemt niks", Output = "niks onderneemt" };

            IList<Mogelijkheid> opties1 = new List<Mogelijkheid>();
            opties1.Add(optie11);
            opties1.Add(optie12);
            opties1.Add(optie13);
            opties1.Add(optie14);

            String outputs1 = "Dit vignet gaat over de manier waarop de sollicitant al dan niet een oordeel velt over de situatie waarin een cliënt een dure GSM koopt terwijl hij beschikt over weinig middelen. De sollicitant geeft hierbij aan dat hij && " +
                "Hij geeft hierbij volgende toelichting $$ Vanuit onderzoek geven cliënten sterk aan dat ze elke vorm van veroordeling over hun gedrag afwijzen.";

            IVraag vraag1 = new VraagMeerkeuze { VraagStelling = "Welke actie onderneemt U?", Vignet = boris, Opties = opties1, Competentie = comp1, OutputString = outputs1 };
            comp1.Vraag = vraag1;

            // comp 3
            Competentie comp3 = new Competentie
            {
                Naam = "Respecteren Zelfbeschikkingsrecht",
                Verklaring = "De hulpverlener respecteert het recht van de cliënt om zelf te beslissen  over zijn/haar situatie, ook al wijkt de beslissing af van de visie van de hulpverlener. Interventies die gericht zijn op het “overnemen” van de situatie bespreekt hij op voorhand met de cliënt zelf."
            };


            IList<Mogelijkheid> opties3 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "interveniëren via derden (bv. psychiater) om het reisplan af te laten lassen omwille van de risico’s." },
                new Mogelijkheid { Input = "niks, dit is zijn individuele keuze en die moet gerespecteerd worden ongeacht de risico’s" },
                new Mogelijkheid { Input = "proberen door gesprek zelfreflectie te stimuleren om toch het idee tot reizen te proberen veranderen" },
                new Mogelijkheid { Input = "adviseren om niet te reizen gezien de risico’s die hieraan verbonden zijn." }
            };

            String output3 = "Deze vraag handelt over de manier waarop de sollicitant omgaat met het zelfbeschikkingsrecht van de cliënt respecteert. Ook de mate waarin situationeel wordt gehandeld wordt afgetoetst. Het voorbeeld wordt gegeven van een cliënt die \"tegen advies\" naar Thailand op reis wil gaan. De sollicitant geeft onderstaand hetgeen hij/zij hiermee zou doen. && Onderstaand de reden voor deze keuze. $$ Vanuit deze verklaring kan u opmaken of de sollicitant werkt vanuit theoretische kaders dan wel eerder vanuit een buikgevoel. Ook de wijze waarop kansen worden geboden kan worden afgetoetst, evenals de al dan niet blijvende verwondering voor de unieke situatie van de cliënt (evt.gevaar op generaliseren).";

            IVraag vraag3 = new VraagMeerkeuze { VraagStelling = "Een cliënt geeft aan dat hij naar Thailand op reis wil gaan. Gezien zijn instabiele psychotische problematiek en risico tot herval in middelengebruik vindt u dit geen goed idee. Wat doet u?",
                Opties = opties3, Competentie = comp3, OutputString = output3,  };

            comp3.Vraag = vraag3;

            // comp 12
            Competentie comp12 = new Competentie
            {
                Naam = "Ondernemingszin",
                Verklaring = "De hulpverlener creëert actief kansen en omstandigheden om de situatie van de cliënt te verbeteren. Hij/zij zet hiertoe in op verschillende niveaus: in de relatie met de cliënt, binnen de eigen organisatie, tussen organisaties én binnen een ruime maatschappelijke context."
            };


            IList<Mogelijkheid> opties12 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "u beschouwt dit als een mogelijke manier om goedkope arbeidskrachten aan te trekken. u vindt dat u hier zelf noch uw organisatie een actieve rol in moeten spelen."},
                new Mogelijkheid { Input = "u ziet hierin een meerwaarde maar u bent bezorgd dat er voorbij zal worden gegaan aan de specifieke kwetsbaarheid van cliënten." },
                new Mogelijkheid { Input = "u vindt dat de private sector en de zorgsector elkaar moeten versterken. Werk is een belangrijke sleutel tot participatief burgerschap." }
            };

            String output12 = "Deze zelfinschaling gaat over hoe de sollicitant reageert op een advertentie van een multinational die projectmatig GGZ cliënten een stage wil aanbieden met oog op mogelijkse vaste tewerkstelling && Wat zal de sollicitant zelf ondernemen en hoe is zijn visie op ondernemerschap op maatschappelijk niveau. Er worden geen uitspraken gedaan over de attitude aangaande ondernemen van de sollicitant zelf. Bovendien wordt ook nagegaan op welke manier dat kwartiermaken wordt bewerkstelligd.";

            IVraag vraag12 = new VraagMeerkeuze
            {
                VraagStelling = "In de krant leest u een advertentie waarin een lokaal bedrijf dat bioverzorgingsproducten produceert een project wil starten waar cliënten uit de GGZ stage kunnen lopen met oog op eventuele tewerkstelling. Een aantal van uw cliënten zou hiervoor in aanmerking kunnen komen. Hoe kijkt u naar dit soort initiatieven?\n Maak een keuze die het best bij u past.",
                Opties = opties12,
                Competentie = comp12,
                OutputString = output12
            };

            comp12.Vraag = vraag12;

            // comp 15
            Competentie comp15 = new Competentie
            {
                Naam = "Zorgzaamheid",
                Verklaring = "De hulpverlener vertoont een authentieke betrokkenheid en zorgzame houding naar cliënten en collega’s"
            };


            IList<Mogelijkheid> opties15 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "wens respecteren en zelf geen contact meer zoeken"},
                new Mogelijkheid { Input = "sporadisch contact zoeken" },
                new Mogelijkheid { Input = "zelfde continuïteit van contact continueren" },
                new Mogelijkheid { Input = "intensiteit contacten verhogen" }
            };

            String output15 = "Op basis van een vignet wordt gevraagd wat de sollicitant zou doen indien een cliënt met een afhankelijkheidsproblematiek stevig doordrinkt en als hulpverlener niet meer wordt toegelaten. De sollicitant geeft aan dat hij in een soortgelijke situatie onderstaand zou ondernemen && rationale:$$";

            IVraag vraag15 = new VraagMeerkeuze
            {
                VraagStelling = "Thomas blijkt door te schieten in een herval en drinkt stevig door. Op een bepaald moment weigert hij jou als hulpverlener nog toe te laten. Wat doet u?",
                Opties = opties15,
                Competentie = comp15,
                OutputString = output15,
                Vignet = thomas
            };

            comp15.Vraag = vraag15;

            // comp 42 
            Competentie comp42 = new Competentie
            {
                Naam = "Kunnen afronden van een hulpverlenersrelatie",
                Verklaring = "De hulpverlener is er zich van bewust dat het afronden van een hulpverlenersrelatie voor cliënten betekent dat er afscheid moet worden genomen van een intieme vertrouwensrelatie.  De hulpverlener zorgt voor een graduele overgang en betrekt indien nodig reeds op voorhand de hulpverleners of mantelzorgers die de zorg zullen overnemen."
            };


            IList<Mogelijkheid> opties42 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "deze stopt, want de cliënt is weg van de afdeling. Het contact stopt volledig", Output = "hij stopt het contact volledig"},
                new Mogelijkheid { Input = "deze stopt want de cliënt is weg, maar ik neem nog sporadisch telefonisch contact", Output = "hij neemt nog sporadisch telefonisch contact" },
                new Mogelijkheid { Input = "de cliënt heeft nood aan opvolging, dus ik ga frequent langs in samenspraak met het mobiel team.", Output = "hij gaat frequent langs, samen met de diensten die de zorg verder zullen opnemen"},
                new Mogelijkheid { Input = "deze moet gradueel afgerond worden in samenspraak met het mobiel team en ik pleit ervoor om nog aan huis te gaan", Output = "hij zal het contact gradueel afronden en de transitie naar een andere dienst faciliteren" }
            };

            String output42 = "In functie van het gradueel kunnen afronden van een hulpverlenersrelatie ziet de sollicitant onderstaande act als reactie op het plotse ontslag van een cliënt op de dienst && Volgend wordt weergeven om deze keuze te verantwoorden: $$";

            IVraag vraag42 = new VraagMeerkeuze
            {
                VraagStelling = "Kurt en vriendin verlaten de afdeling en worden wekelijks opgevolgd door een mobiel team. U werkt zelf op de residentiële afdeling. Het contact met het mobiel team verloopt onwennig. Hoe ziet u uw verdere begeleiding?",
                Opties = opties42,
                Competentie = comp42,
                OutputString = output42,
                Vignet = kurt
            };

            comp42.Vraag = vraag42;

            // comp 43
            Competentie comp43 = new Competentie
            {
                Naam = "Going the extra mile",
                Verklaring = "De hulpverlener durft op basis van rationele overwegingen acties te ondernemen om cliënten te ondersteunen, zelfs indien deze afwijken van het gebruikelijke patroon of afspraken in het team.."
            };


            IList<Mogelijkheid> opties43 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = " Niet doen. Dit is tegen de regels van de organisatie en leidt tot willekeur.", Output = "regels volgen eerder dan tegemoet komen aan de noden van de cliënt."},
                new Mogelijkheid { Input = "Voorlopig niet doen. Ik weet het niet en vraag toestemming bij het afdelingshoofd of de psychiater.", Output = "afwijkingen bevragen bij oversten." },
                new Mogelijkheid { Input = "Niet doen. Dit zorgt ervoor dat Kurt afhankelijk blijft van de hulpverlening en dient vermeden te worden", Output = "aftoetsen wat de cliënt toekomstgericht kan helpen in functie van zelfredzaamheid eerder dan een instantoplossing aan te reiken." },
                new Mogelijkheid { Input = " Doen. Kurt wordt op deze manier geholpen, zelfs al is dit tegen de regels", Output = "de hulpverlenersreflex volgen" }
            };

            String output43 = "De sollicitant zal aangaande het gericht afwijken van protocollen en richtlijnen het volgende ondernemen op basis van een casus: && Hij geeft hierbij volgende rationale weer: $$ Indien de sollicitant “doen” aangeeft en geen rationale geeft, kan dit eventueel wijzen op het volgen van hulpverlenersreflex/buikgevoel zonder toepassing van een kader.";

            IVraag vraag43 = new VraagMeerkeuze
            {
                VraagStelling = "Een collega brengt een zetel mee die hij thuis staan heeft naar het werk. Kurt heeft namelijk weinig middelen om zijn appartement in te richten. Dit is echter niet de gewoonte op de dienst. Enkele weken geleden is iemand van de nabije dienst/afdeling aangesproken over het feit dat ze een andere cliënt gaan helpen verven is in zijn nieuw appartement. Uw advies wordt gevraagd. Wat denkt u?",
                Opties = opties43,
                Competentie = comp43,
                OutputString = output43,
                Vignet = kurt
            };

            comp43.Vraag = vraag43;

            //comp 45
            Competentie comp45 = new Competentie
            {
                Naam = "Professionele nabijheid",
                Verklaring = "De hulpverlener is authentiek betrokken op de cliënt en zijn situatie. Hij/zij varieert in de mate van emotionele afstand om in overleg met het team het therapeutisch handelen te waarborgen."
            };


            IList<Mogelijkheid> opties45 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "voldoende afstand te behouden"},
                new Mogelijkheid { Input = "afstand/nabijheid te respecteren" },
                new Mogelijkheid { Input = " vooral nabij te zijn" },
                new Mogelijkheid { Input = "de cliënt het gevoel te geven  een vriend te zijn" }
            };

            String output45 = "De sollicitant geeft aan dat hij binnen een therapeutische relatie onderstaand het belangrijkste te vinden && Hij geeft hiervoor volgende uitleg $$ Uit ons onderzoek blijkt dat het gevoel van nabijheid als een essentiële voorwaarde voor goede zorg wordt beschouwd.";

            IVraag vraag45 = new VraagMeerkeuze
            {
                VraagStelling = "In een therapeutische relatie vind ik het belangrijk om",
                Opties = opties45,
                Competentie = comp45,
                OutputString = output45,
            };

            comp45.Vraag = vraag45;

            // comp 46
            Competentie comp46 = new Competentie
            {
                Naam = "Adviseren & individuele psycho-educatie",
                Verklaring = "De hulpverlener kan een inschatting maken wanneer advies een meerwaarde betekent en kan dit op een correcte en niet-belerende manier overbrengen."
            };


            IList<Mogelijkheid> opties46 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Advies is uit den boze, u moet de cliënt volgen in zijn denkparcours. wanneer hij/zij er klaar voor is zal hij dit zelf wel aangeven", Output = "niet adviseren, cliënt geeft zelf aan wanneer hij hiervoor klaar is"},
                new Mogelijkheid { Input = "Advies om te vermageren is nodig omdat dit één van uw verantwoordelijkheden als hulpverlener is", Output = "zelf  adviseren vanuit professioneel verantwoordelijkheidsgevoel" },
                new Mogelijkheid { Input = "U adviseert niet zelf maar stuurt de cliënt door naar een diëtist",  Output = "Niet zelf adviseren maar wel doorverwijzen naar diëtist" }
            };

            String output46 = "een cliënt moet omwille van medische redenen vermageren. De sollicitant geeft aan dat hij volgende actie zou ondernemen && De sollicitant geeft volgende toelichting $$";

            IVraag vraag46 = new VraagMeerkeuze
            {
                VraagStelling = "Een cliënt houdt er een ongezond eetpatroon op na en de psychiater geeft aan dat de cliënt moet afslanken. Wat doet u?",
                Opties = opties46,
                Competentie = comp46,
                OutputString = output46,
            };

            comp46.Vraag = vraag46;

            // comp 49
            Competentie comp49 = new Competentie
            {
                Naam = "Omgaan met grensoverschrijdend gedrag",
                Verklaring = "De hulpverlener kan omgaan met situaties die zijn persoonlijke grenzen overschrijden zoals intimidatie en agressie."
            };


            IList<Mogelijkheid> opties49 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Ik houd dit voorlopig voor mezelf en wacht af", Output = "voor zichzelf houden"},
                new Mogelijkheid { Input = "Ik deel dit onmiddellijk met een bevriende collega of een vertrouwenspersoon", Output = "delen met bevriende collega of vertrouwenspersoon" },
                new Mogelijkheid { Input = "ik deel dit met een professional die geen deel uitmaakt van mijn werkcontext" , Output = "delen met een externe professional"},
                new Mogelijkheid { Input = "Ik breng mijn  leidinggevende op de hoogte", Output = "delen met een leidinggevende" },
                new Mogelijkheid { Input = "Ik deel dit zo snel als mogelijk  in het grote teamoverleg", Output = "delen in het team" }
            };

            String output49 = "Onderstaand wordt via een casus nagegaan hoe de sollicitant omgaat met grensoverschrijdend gedrag onder de vorm van agressieve spanning. De sollicitant zal dit &&";

            IVraag vraag49 = new VraagMeerkeuze
            {
                VraagStelling = "Ofschoon Murat zeer beleefd blijft voelt u wel een agressieve spanning in de kamer hangen die sterk naar jou gericht is. Wat is uw eerste reactie zodra u buiten stapt?",
                Opties = opties49,
                Competentie = comp49,
                OutputString = output49,
                Vignet = murat
            };

            comp49.Vraag = vraag49;

            // comp 60
            Competentie comp60 = new Competentie
            {
                Naam = "Omgaan met onmacht en eigen frustratie",
                Verklaring = "De hulpverlener kan zijn onmacht kanaliseren via het team en kan hierbij eigen frustraties op een respectvolle manier ventileren naar collega’s."
            };


            IList<Mogelijkheid> opties60 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Ik laat de situatie zoals ze is. Dit is inherent aan de job", Output = "frustraties snel naast zich zal neerleggen en dit zien als eigen aan de job" },
                new Mogelijkheid { Input = "Ik ventileer binnen het team bij collega’s", Output = "ventileren binnen het team bij collega’s" },
                new Mogelijkheid { Input = "Ik ventileer bij mijn direct leidinggevende of psychiater", Output = "ventileren bij leidinggevenden" },
                new Mogelijkheid { Input = "Ik verwerk dit zelf, dit raakt me maar ik vind niet dat ik hier anderen lastig mee moet vallen.", Output = "het zelf zal proberen verwerken"}
            };

            String output60 = "De sollicitant geeft aan dat hij in geval van frustraties ten gevolge van niet nagekomen afspraken waarschijnlijk als volgt zal reageren:";

            IVraag vraag60 = new VraagMeerkeuze
            {
                VraagStelling = "Er werd binnen het team beslist dat Kamiel toch verder kon opgevolgd worden. Het drinken van Kamiel loopt echter volledig uit de hand. u hebt al 4 afspraken gemaakt, Kamiel kwam deze niet na. Voor de laatste afspraak hebt u zelfs het oudercontact van uw zoontje gemist en is uw partner alleen moeten gaan. Wat doet u met uw gevoel?",
                Opties = opties60,
                Competentie = comp60,
                OutputString = output60,
                Vignet = kamiel
            };

            comp60.Vraag = vraag60;

            // comp 73
            Competentie comp73 = new Competentie
            {
                Naam = "Omgaan met tegenoverdracht",
                Verklaring = "De hulpverlener is zich bewust van gevoelens van tegenoverdracht.  Hij/zij is in staat om te reflecteren van waaruit dit komt en kan dit bespreekbaar stellen."
            };


            IList<Mogelijkheid> opties73 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "ik ga voor mezelf op zoek naar de reden"},
                new Mogelijkheid { Input = "ik contacteer  een collega om mijn gevoel te bespreken" },
                new Mogelijkheid { Input = "ik maak dit bespreekbaar bij  de cliënt" },
                new Mogelijkheid { Input = "ik contacteer mijn  leidinggevende om tot een oplossing te komen" },
                new Mogelijkheid { Input = "ik onderneem  stappen om de relatie van mijn kant te proberen verbeteren" }
            };

            String output73 = "Onderstaand geeft de sollicitant aan op welke manier hij zou omgaan met tegenoverdracht && De sollicitant geeft hierbij volgende verklaring: $$ Het is belangrijk dat hulpverleners een manier vinden om deze situatie om te buigen tot een reflectiemoment. Er wordt ook nagegaan of men dit proces zelf in handen neemt of men hiervoor beroep doet op anderen.";

            IVraag vraag73 = new VraagMeerkeuze
            {
                VraagStelling = "U komt bij een nieuwe cliënt aan huis waar u bijna onmiddellijk een antipathie voor voelt. Dit gevoel blijft ook na de volgende bezoeken aanwezig. Wat doet u?",
                Opties = opties73,
                Competentie = comp73,
                OutputString = output73,
                Vignet = boris
            };

            comp73.Vraag = vraag73;

            // comp 75
            Competentie comp75 = new Competentie
            {
                Naam = "Positive risk taking",
                Verklaring = "De wens van de cliënt volgen kan in sommige gevallen een zeker risico inhouden. De hulpverlener maakt hierbij een bewuste afweging tussen de eigen inschatting van een situatie enerzijds  en de manier waarop de cliënt de situatie ziet."
            };


            IList<Mogelijkheid> opties75 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "laten gaan"},
                new Mogelijkheid { Input = "binnenhouden" }
            };

            String output75 = "Op basis van de vraag of de sollicitant een door hem suïcidaal geachte cliënt uitgang zou verlenen wordt zijn attitude tot positive risk taking ingeschat. De sollicitant zou in dit geval de cliënt && Hij baseert zich hiervoor op volgende gedachtengang $$ Binnen onderzoek geven cliënten en medewerkers aan dat het belangrijk is dat hulpverleners beslissingen nemen die de cliënt en zijn situatie ten goede komen, maar die een mogelijks risico kunnen inhouden.";

            IVraag vraag75 = new VraagMeerkeuze
            {
                VraagStelling = "Een patiënt vraagt tijdens een residentiële opname op zondag om een wandeling te mogen doen tijdens de uitgangsuren. Daags tevoren had u er een gesprek mee waar hij aangaf concrete suïcidale ideeën te hebben. Hij geeft aan dat hij deugd zou hebben van een wandeling maar dat de zwarte gedachten nog in zijn hoofd spoken. Wat doet u?",
                Opties = opties75,
                Competentie = comp75,
                OutputString = output75,
            };

            comp75.Vraag = vraag75;

            // comp 81
            Competentie comp81 = new Competentie
            {
                Naam = "Controleren",
                Verklaring = "De hulpverlener is er zich van bewust dat controle gericht is op het ondersteunen van de cliënt en dus niet tot een automatisme mag verworden. Controle vereist immers het mandaat van de cliënt. Controle als interventie moet op regelmatige basis samen met de cliënt op zijn therapeutische meerwaarde worden geëvalueerd."
            };


            IList<Mogelijkheid> opties81 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Ik zie dit niet als mijn taak, ik neem een afwachtende houding aan", Output = "geen van zijn opdrachten"},
                new Mogelijkheid { Input = "Ik zie dit niet als mijn taak tenzij de cliënt hier expliciet zelf om vraagt", Output = "geen expliciete taak om de veiligheid te garanderen tenzij de cliënt hier zelf om vraagt" },
                new Mogelijkheid { Input = "Ik vind het mijn taak om dit te controleren teneinde de veiligheid van Thomas te garanderen. Ik doe dit discreet, zonder dat hij het weet", Output = "één van zijn taken die discreet verscholen is in het dagdagelijkse handelen" },
                new Mogelijkheid { Input = "Ik vind het belangrijk om Thomas hierover rechtstreeks aan te spreken", Output = "Eén van de taken waarbij er directe vragen worden gesteld over het te controleren topic." }
            };

            String output81 = "Onderstaand staat beschreven hoe  de sollicitant staat tegenover het uitoefenen van controle. de sollicitant ziet dit als && Hij/zij geeft hiervoor volgende motivatie weer $$ De motivatie qua keuze is belangrijk. Cliënten geven in onderzoek immers aan dat ze controle door hun hulpverlener in bepaalde omstandigheden als zinvol ervaren. Een essentiele voorwaarde is echter dat ze zelf een fiatering gegeven hebben en het controleren niet al te expliciet gebeurt.";

            IVraag vraag81 = new VraagMeerkeuze
            {
                VraagStelling = "Zoals in de casus vermeld hebt u een vermoeden dat Thomas drinkt. In welke mate hebt u als hulpverlener de taak om het drankgebruik van Thomas te controleren:",
                Opties = opties81,
                Competentie = comp81,
                OutputString = output81,
                Vignet = thomas
            };

            comp81.Vraag = vraag81;

            //// template vraagmeerkeuze
            //Competentie compM = new Competentie
            //{
            //    Naam = "",
            //    Verklaring = ""
            //};


            //IList<Mogelijkheid> opties = new List<Mogelijkheid>()
            //{
            //    new Mogelijkheid { Input = ""},
            //    new Mogelijkheid { Input = "" },
            //    new Mogelijkheid { Input = "" },
            //    new Mogelijkheid { Input = "" }
            //};

            //String outputM = "";

            //IVraag vraagM = new VraagMeerkeuze
            //{
            //    VraagStelling = "",
            //    Opties = opties3,
            //    Competentie = comp3,
            //    OutputString = output3,
            //};

            //compM.Vraag = vraagM;

            // OPEN VRAGEN
            // comp 10
            Competentie comp10 = new Competentie
            {
                Naam = "Betrouwbaar en echtheid",
                Verklaring = "De acties die de hulpverlener stelt zijn congruent met diens persoonlijkheid, uitstraling, bedoelingen uitspraken en acties. De hulpverlener doet wat hij zegt en zegt wat hij doet."
            };

            String output10 = "Indien er een keuze moet gemaakt worden tussen het voeren van een vooraf gepland gesprek en de last minute bespreking van een cliënt die de sollicitant zou begeleiden zal de sollicitant volgend ondernemen << Onderstaand zijn beweegreden hiertoe $$ Hulp ter interpretatie: cliënten geven aan dat ze het zeer belangrijk vinden dat hulpverleners zich aan hun woord houden.";

            IVraag vraag10 = new VraagOpen
            {
                VraagStelling = "U hebt een gesprek met een cliënt gepland. Uw afdelingshoofd vraagt u ‘s morgens om zeker aanwezig te zijn op de teambespreking omdat één van de cliënten die u opvolgt daar zal besproken worden.",
                Competentie = comp10,
                OutputString = output10,
            };

            comp10.Vraag = vraag10;

            // comp 32
            Competentie comp32 = new Competentie
            {
                Naam = "Evidence based werken",
                Verklaring = "De hulpverlener combineert in zijn zorginterventies eigen expertise, wetenschappelijke evidentie ervaringskennis en vertaalt dit naar de individuele situatie van de cliënt."
            };

            String output32 = "De sollicitant geeft aan dat hij het conceptualiseren van goede zorg op basis van evidence based handelen als volgt ziet: >> Belangrijk hierbij is dat de sollicitant achterliggende principes van richtlijnen, meetinstrumenten, concepten, modellen, tools etc. kent en het gebruik ervan niet reduceert tot een louter uitvoering ervan.";

            IVraag vraag32 = new VraagOpen
            {
                VraagStelling = "Hoe ziet u de verhouding tussen wetenschappelijke evidentie, eigen expertise en ervaringskennis binnen het verlenen van een goede kwaliteit van zorg? Licht bondig toe?",
                Competentie = comp32,
                OutputString = output32,
            };
            comp32.Vraag = vraag32;

            // comp 41
            Competentie comp41 = new Competentie
            {
                Naam = "Connectie maken via dagdagelijksheid",
                Verklaring = "De hulpverlener gebruikt de dagdagelijkse context om een authentiek contact met de cliënt te bewerkstelligen en tot verdieping te komen in de gesprekken."
            };

            String output41 = "Onderstaand wordt weergegeven hoe de sollicitant kijkt naar alledaagse gesprekken. >> Uit ons onderzoek blijkt dat het bewust aanwenden van dagdagelijkse gesprekken als belangrijke competentie wordt geacht om contact te bewerkstelligen en in een latere fase mogelijke verandering te initiëren.";

            IVraag vraag41 = new VraagOpen
            {
                VraagStelling = "Hoe kijkt u naar gesprekken over alledaagse zaken met cliënten (zoals over het weer, de voetbal, …) en hoe gaat u hiermee om?",
                Competentie = comp41,
                OutputString = output41,
            };
            comp41.Vraag = vraag41;

            // comp 51
            Competentie comp51 = new Competentie
            {
                Naam = "Bieden hoop- en zingeving",
                Verklaring = "De hulpverlener blijft de cliënt prikkelen om in zichzelf en zijn krachten te geloven."
            };

            String output51 = "Onderstaand geeft de sollicitant weer hoe hij als hulpverlener bijdraagt tot het bieden van hoop- en zingeving. >> Beperkt zich dit tot concreet niveau of is dit abstracter? Kadert dit in een kwaliteitsvol bestaan? is dit ingebed in het dagdagelijks denken en handelen ?";
  

              IVraag vraag51 = new VraagOpen
              {
                VraagStelling = "Hoop en zingeving zijn belangrijke elementen voor een zinvol bestaan. Hoe kan u hiertoe bijdragen als hulpverlener? Geef een concreet voorbeeld",
                Competentie = comp51,
                OutputString = output51,
            };
            comp51.Vraag = vraag51;

            // comp 56
            Competentie comp56 = new Competentie
            {
                Naam = "Luistervaardigheden",
                Verklaring = "De hulpverlener maakt tijd om op een onbevangen manier naar de cliënt te luisteren zonder zijn eigen bedenkingen of ideeën in te laten overheersen."
            };

            String output56 = "Onderstaand beschrijft de sollicitant op welke manier hij/zij zou reageren op de casus van Anna. >> Naast de eventuele uiting van subjectieve interpretaties kan u nagaan of de sollicitant eerder gericht is op actieve tussenkomsten dan wel op luisterbereidheid. Uit ons onderzoek blijkt immers dat in functie van de vertrouwensband goed luisteren naar het probleem erg belangrijk is vooraleer tot actie wordt overgegaan.Deze casus  is sterk gericht op de crisissituatie.Toch is het van belang om ook na te gaan of de sollicitant spontaan de sterktes van Anna benoemt en ermee aan de slag gaat in het gesprek.";

            IVraag vraag56 = new VraagOpen
            {
                VraagStelling = "Wat doet u, wat denkt u en waarom? ",
                Competentie = comp56,
                OutputString = output56,
                Vignet = anna
            };
            comp56.Vraag = vraag56;

            // comp 69
            Competentie comp69 = new Competentie
            {
                Naam = "De vraag achter de hulpvraag detecteren",
                Verklaring = "De hulpverlener exploreert de eigenlijke noden en vragen die zich achter de initiële hulpvraag of -appel schuilhouden."
            };

            String output69 = "De sollicitant geeft aan dat als mening over de stelling \"hulpverleners moeten blijven zoeken naar het waarom achter de initiële hulpvraag\" >> Uit onderzoek blijkt dat het van belang is dat de hulpvraag veelal evolueert doorheen de tijd en vorm krijgt doorheen het proces van de therapeutische relatie.";

            IVraag vraag69 = new VraagOpen
            {
                VraagStelling = "Geef uw mening weer over onderstaande stelling \"Hulpverleners moeten blijven zoeken naar het waarom achter de initiële hulpvraag\"",
                Competentie = comp69,
                OutputString = output69,
            };
            comp69.Vraag = vraag69;

            // comp 76
            Competentie comp76 = new Competentie
            {
                Naam = "Zorgplan opmaken",
                Verklaring = "De hulpverlener kan een zorgplan opmaken dat gefaseerd is en subdoelstellingen evenals evaluatiemomenten bevat. Hij monitort dit continu en past het plan aan wanneer en waar nodig."
            };

            String output76 = "De sollicitant geeft op basis van het vignet van Kurt onderstaand rudimentair zorgplan weer. Om dit te interpreteren kan U volgende zaken in overweging nemen: \n-\t Komen verschillende levensdomeinen, voldoende aan bod? \n-\t Worden er evaluatiemomenten ingebouwd? \n-\t Worden  sterktes ook geëxploreerd? \n-\t Wordt de cliënt gehoord, zorg voor context? \n-\t Is de intensiteit van het zorgplan afgestemd op de noden van de cliënt(niet te veel, niet te weinig)? \n-\t Wordt alles “gepathologiseerd” of wordt de reflectie gemaakt dat bepaald gedrag misschien perfect normaal is? \n-\t Op welke manier wordt er rekening gehouden met het sociaal isolement van de cliënt? \n-\t Worden andere organisaties betrokken of zal de sollicitant alles alleen opnemen ? (netwerkgerichtheid)";

            IVraag vraag76 = new VraagOpen
            {
                VraagStelling = "Maak een oplijsting in trefwoorden van maximum 10 prioritaire aandachtspunten en noteer per trefwoord in maximum 1 zin hoe u hiermee aan de slag zou gaan.",
                Competentie = comp76,
                OutputString = output76,
                Vignet = kurt
            };
            comp76.Vraag = vraag76;

            // comp 79
            Competentie comp79 = new Competentie
            {
                Naam = "Succeservaringen creëren en bekrachtigen",
                Verklaring = "De hulpverlener creëert of expliciteert succeservaringen en maakt tijd om deze samen met de cliënt te valoriseren."
            };

            String output79 = "Via een vignet wordt nagegaan in welke mate de sollicitant succeservaringen zal bekrachtigen; onderstaand wordt het antwoord gegeven van de sollicitant op de vraag hoe hij met de situatie zou omgaan indien de cliënt de job heeft >> Voor de interpretatie is het van belang te  checken of de sollicitant hierbij de focus zal leggen op de bevestiging van het succes enerzijds of op potentiële valkuilen anderzijds";

            IVraag vraag79 = new VraagOpen
            {
                VraagStelling = "Bij een volgende huisbezoek zegt Thomas dat hij  de job als taxichauffeur heeft. Hoe reageert u hierop?",
                Competentie = comp79,
                OutputString = output79,
                Vignet = thomas
            };
            comp79.Vraag = vraag79;

            //// temp
            //Competentie comp = new Competentie
            //{
            //    Naam = "",
            //    Beschrijving = ""
            //};

            //String output = "";

            //IVraag vraag = new VraagOpen
            //{
            //    VraagStelling = "",
            //    Competentie = comp,
            //    OutputString = output,
            //};
            //comp.Vraag = vraag;

            // RUBRICS VRAGEN AKA DYING

            // comp 8
            IList<Mogelijkheid> opties8 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "contacten met cliënten te beperken tot eerder gemaakte afspraak bereikbaar te zijn voor ondersteuning tussen bepaalde uren (vb. kantooruren)", Aanvulling = "contacten met cliënten te beperken tot eerder gemaakte afspraak bereikbaar te zijn voor ondersteuning tussen bepaalde uren (vb. kantooruren)" },
                new Mogelijkheid { Input = "ook buiten de werkuren bereikbaar te zijn indien de situatie dit vereist" , Aanvulling = "ook buiten de werkuren bereikbaar te zijn indien de situatie dit vereist"}
            };

            Aanvulling aanvulling8 = new Aanvulling
            {
                Beschrijving = "",
                Opties = opties8.ToList()
            };

            Competentie comp8 = new Competentie
            {
                Naam = "Presentie",
                Verklaring = "De hulpverlener is nabij en beschikbaar voor ondersteuning, ook al zijn er geen handelingen of interventies nodig. Hij is deelgenoot van moeilijke en positieve momenten in het leven van de cliënt.",
                Aanvulling = aanvulling8
            };

            IVraag vraag8 = new VraagRubrics
            {
                VraagStelling = "De financiële rendabiliteit van een afdeling/dienst is: ",
                Opties = opties8,
                Competentie = comp8,
                OutputString= "In deze sectie toetsen we wegens de complexiteit enkel de component “bereikbaarheid” af te toetsen als onderdeel van presentie. De sollicitant geeft aan dat hij in functie van bereikbaarheid wenst && Hij geeft hiervoor volgende toelichting weer $$"
            };

            comp8.Vraag = vraag8;


            // comp 9
            IList<Mogelijkheid> opties9 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "het niet nodig is om me in elke situatie volledig te kunnen inleven in de leefwereld van cliënten", Aanvulling = "het niet nodig is om me in elke situatie volledig te kunnen inleven in de leefwereld van cliënten" },
                new Mogelijkheid { Input = "het wel nodig is om me in elke situatie te kunnen inleven in de leefwereld van cliënten" , Aanvulling = "het wel nodig is om me in elke situatie te kunnen inleven in de leefwereld van cliënten"}
            };

            Aanvulling aanvulling9 = new Aanvulling
            {
                Beschrijving = "",
                Opties = opties9.ToList()
            };

            Competentie comp9 = new Competentie
            {
                Naam = "Empathie",
                Verklaring = "De hulpverlener kan zich inleven in de situatie van de cliënt en kan hierbij diens gedachtengang, gevoelens en verlangens capteren en terugkoppelen.",
                Aanvulling = aanvulling9
            };

            IVraag vraag9 = new VraagRubrics
            {
                VraagStelling = "Ik denk dat",
                Opties = opties9,
                Competentie = comp9, 
                OutputString = "De sollicitant geeft aan dat hij zich && Hij geeft hiervoor volgende uitleg $$ Deze uitleg is belangrijk om in te schatten welke betekenis de sollicitant toekent aan empathie in een professionele relatie(eerder realistisch dan wel idealistisch). Tegelijkertijd kan worden gepeild naar de mate van zelfinzicht in bepaalde omstandigheden die empathie kan bemoeilijken bv.pedofilie, eigen ervaringen etc."
            };
            comp9.Vraag = vraag9;

            // comp 13
            IList<Mogelijkheid> opties13 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "niet van belang, in de zorgsector zijn we hulpverleners, geen managers", Aanvulling = "niet van belang", IsSchrapOptie = true },
                new Mogelijkheid { Input = "de verantwoordelijkheid van de leidinggevende(n). Mijn verantwoordelijkheid is het verstrekken van goede zorg" , Aanvulling = "is de verantwoordelijkheid van de leidinggevende(n)"},
                new Mogelijkheid { Input = "ook voor mij van belang. Elke zorgverlener waakt  mee over de financiële gezondheid van de voorziening.", Aanvulling = "indien genoodzaakt moeten we de zorg mede afstemmen op financiële haalbaarheid van de voorziening." }
            };

            Aanvulling aanvulling13 = new Aanvulling
            {
                Beschrijving = "Geef onderstaand  aan welke houding u verwacht van uw medewerker aangaande marktgerichtheid en medezorg voor financiële gezonde status van de organisatie",
                Opties = opties13.ToList()
            };


            Competentie comp13 = new Competentie
            {
                Naam = "Organisatiegericht denken",
                Verklaring = "De hulpverlener denkt actief mee over het efficiënt inzetten van middelen en eigen zorgactiviteiten in functie van de zorg.",
                Aanvulling = aanvulling13
            };

            IVraag vraag13 = new VraagRubrics
            {
                VraagStelling = "De financiële rendabiliteit van een afdeling/dienst is: ",
                Opties = opties13,
                Competentie = comp13,
                OutputString = "Onderstaand geeft de sollicitant zijn mening weer weer over het belang van socioeconomie in de zorg"
            };

            comp13.Vraag = vraag13;

            // comp 16
            IList<Mogelijkheid> opties16 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "in mijn werk baseer ik me vooral  op de expertise en voorbeeldfunctie van ervaren collega’s", Aanvulling = "te leunen op de expertise van collega’s" },
                new Mogelijkheid { Input = "in mijn werk durf ik mezelf toelaten om fouten te maken om hieruit te leren" , Aanvulling = "zichzelf toe te laten fouten te maken en hieruit te leren"},
                new Mogelijkheid { Input = " in mijn werk volg ik ontwikkelingen in het werkveld op de voet via diverse kanalen om hieruit te leren (vb. tijdschriften, websites, etc.)", Aanvulling = "ontwikkelingen in het werkveld op de voet te volgen via diverse media" }
            };

            Aanvulling aanvulling16 = new Aanvulling
            {
                Beschrijving = "Welke minimale houding verwacht u van de toekomstige medewerker inzake leren? Deze dient vooral te leren door",
                Opties = opties16.ToList()
            };

            Competentie comp16 = new Competentie
            {
                Naam = "Levenslang en breed leren",
                Verklaring = "De hulpverlener volgt de actuele ontwikkelingen in het werkgebied nauwgezet op. Hij/zij werkt continu bewust aan zijn/haar zelfontwikkeling, ook los van de werksituatie.",
                Aanvulling = aanvulling16
            };

            IVraag vraag16 = new VraagRubrics
            {
                VraagStelling = "Welke van de volgende stellingen past het best bij uw situatie?",
                Opties = opties16,
                Competentie = comp16,
                OutputString = "De sollicitant geeft aan vooral te leren door &&"
            };

            comp16.Vraag = vraag16;

            // comp 18
            IList<Mogelijkheid> opties18 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "zo weinig mogelijk te onthullen over mijzelf", Aanvulling = "zo weinig mogelijk te onthullen over mijzelf", Output = "niks te onthullen over zichzelf" },
                new Mogelijkheid { Input = "een vriend te zijn voor de cliënt" , Aanvulling = "een vriend te zijn voor de cliënt", Output = "een vriend te zijn voor cliënten" },
                new Mogelijkheid { Input = "veel over te brengen omdat dit mij tot een “echter” persoon maakt", Aanvulling = "veel over te brengen omdat dit mij tot een “echter” persoon maakt", Output = "veel te brengen over zichzelf" },
                new Mogelijkheid { Input = "af en toe iets te zeggen over mezelf waarvan ik vermoed  dat het de therapeutische relatie kan versterken", Aanvulling = "af en toe iets te zeggen over mezelf waarvan ik vermoed  dat het de therapeutische relatie kan versterken", Output = "veel te brengen over zichzelf"}
            };

            Aanvulling aanvulling18 = new Aanvulling
            {
                Beschrijving = "",
                Opties = opties18.ToList()
            };

            Competentie comp18 = new Competentie
            {
                Naam = "Zelfonthulling",
                Verklaring = "De hulpverlener kan bewust en gericht zaken over zijn eigen leefsituatie inbrengen die de cliënt kunnen vooruit helpen of contact faciliteren (drempelverlagend, verhoogt herkenbaarheid).",
                Aanvulling = aanvulling18
            };

            IVraag vraag18 = new VraagRubrics
            {
                VraagStelling = "Ik vind het belangrijk om ten opzichte van cliënten",
                Opties = opties18,
                Competentie = comp18, 
                OutputString = "De sollicitant geeft aan dat hij het belangrijk vindt om && Bijkomende uitleg $$"
            };

            comp18.Vraag = vraag18;

            // comp 19
            IList<Mogelijkheid> opties19 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "naar directe oorzaken te zoeken van bepaald gedrag en om hierop gericht  in te spelen", Aanvulling = "Lineair denken: oorzaak-gevolg, gaat op zoek naar oplossingen eerder dan naar dynamieken", Output = "lineair" },
                new Mogelijkheid { Input = "niet op zoek te gaan naar directe oorzaken maar vanuit een bredere context het gedrag te proberen begrijpen en hierop in te spelen" , Aanvulling = "circulair: gaat op zoek naar systemen die problemen of situaties in stand houden ipv oplossingen te detecteren", Output = "circulair" }
            };

            Aanvulling aanvulling19 = new Aanvulling
            {
                Beschrijving = "Welke manier van denken wenst u dat de toekomstige medewerker hoofdzakelijk vertoont:",
                Opties = opties19.ToList()
            };

            Competentie comp19 = new Competentie
            {
                Naam = "Circulair denken",
                Verklaring = "De hulpverlener is er zich van bewust dat er niet altijd een direct verband is tussen een bepaalde gedraging en de problemen die optreden. Een directe oplossing om de probleem te verhelpen bestaat meestal niet. De hulpverlener kan patronen van interacties herkennen in ruimere context.",
                Aanvulling = aanvulling19
            };

            IVraag vraag19 = new VraagRubrics
            {
                VraagStelling = "Ik ben eerder geneigd om:",
                Opties = opties19,
                Competentie = comp19, 
                OutputString = "De sollicitant geeft aan dat hij er bij voorkeur een && denken op nahoudt. \nUit ons onderzoek blijkt dat een goed evenwicht tussen beide manieren van denken bij de hulpverlener belangrijk is. Daarnaast bleek ook dat op teamniveau een gezond evenwicht tussen de zogenaamde denkers en doeners  een belangrijke meerwaarde is"
            };

            comp19.Vraag = vraag19;

            // comp 20
            IList<Mogelijkheid> opties20 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig kennis van psychopathologie", Aanvulling = "geen/weinig kennis van psychopathologie", IsSchrapOptie = true },
                new Mogelijkheid { Input = "basiskennis over alle frequent voorkomende psychiatrische aandoeningen" , Aanvulling = "basiskennis"},
                new Mogelijkheid { Input = "een vergevorderde kennis over alle frequent voorkomende psychiatrische aandoeningen", Aanvulling = "vergevorderde kennis" }
            };

            Aanvulling aanvulling20 = new Aanvulling
            {
                Beschrijving = "Duid de kennisgraad aan die u verwacht aangaande psychopathologie",
                Opties = opties20.ToList()
            };

            Competentie comp20 = new Competentie
            {
                Naam = "Psychopathologie",
                Verklaring = "De hulpverlener heeft kennis over psychopathologie, etiologie, symptomen en de potentiële impact van een psychiatrische pathologie op de mens.",
                Aanvulling = aanvulling20
            };

            IVraag vraag20 = new VraagRubrics
            {
                VraagStelling = "Duid de stelling aan die het meest bij u past. Ik heb",
                Opties = opties20,
                Competentie = comp20
            };

            comp20.Vraag = vraag20;

            // comp 21
            IList<Mogelijkheid> opties21 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig kennis over psychofarmaca", Aanvulling = " geen/weinig kennis over psychofarmaca", IsSchrapOptie = true },
                new Mogelijkheid { Input = "basiskennis over de effecten en bijwerking van de  meest courante psychofarmaca" , Aanvulling = "basiskennis"},
                new Mogelijkheid { Input = "een vergevorderde kennis over de effecten  en bijwerking van de meest courante psychofarmaca", Aanvulling = "vergevorderde kennis" }
            };

            Aanvulling aanvulling21 = new Aanvulling
            {
                Beschrijving = "Duid de kennisgraad aan die u verwacht aangaande psychofarmaca",
                Opties = opties21.ToList()
            };

            Competentie comp21 = new Competentie
            {
                Naam = "Psychofarmacologie",
                Verklaring = "De hulpverlener heeft kennis over de werking, bijwerking van psychofarmacologie, alsook interventies die medicatietrouw kunnen bevorderen.",
                Aanvulling = aanvulling21
            };

            IVraag vraag21 = new VraagRubrics
            {
                VraagStelling = "Duid de stelling aan die het meest bij u past. Ik heb",
                Opties = opties21,
                Competentie = comp21,
                OutputString = "De sollicitant geeft aan dat hij onderstaande kennis heeft over de effecten en bijwerkingen van psychofarmaca. &&"
            };

            comp21.Vraag = vraag21;

            // comp 22
            IList<Mogelijkheid> opties22 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig kennis over lichamelijke problematieken", Aanvulling = "geen/weinig kennis", IsSchrapOptie = true },
                new Mogelijkheid { Input = "basiskennis over lichamelijke  aandoeningen" , Aanvulling = "basiskennis"},
                new Mogelijkheid { Input = "een gevorderde kennis over lichamelijke aandoeningen", Aanvulling = "gevorderde kennis" }
            };

            Aanvulling aanvulling22 = new Aanvulling
            {
                Beschrijving = "Duid de kennisgraad aan die u verwacht aangaande somatische problematieken",
                Opties = opties22.ToList()
            };

            Competentie comp22 = new Competentie
            {
                Naam = "Somatische problemen",
                Verklaring = "De hulpverlener heeft kennis over de meest voorkomende somatische problemen die voorkomen binnen een aantal doelgroepen in de GGZ.",
                Aanvulling = aanvulling22
            };

            IVraag vraag22 = new VraagRubrics
            {
                VraagStelling = "Duid de stelling aan die het meest bij u past. Ik heb",
                Opties = opties22,
                Competentie = comp22,
                OutputString = "De sollicitant geeft aan dat hij onderstaande kennis heeft over de somatische problematieken. &&"
            };

            comp22.Vraag = vraag22;

            // comp 23
            IList<Mogelijkheid> opties23 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig kennis over leefstijlfactoren die somatische risico’s inhouden", Aanvulling = "geen/weinig kennis", IsSchrapOptie = true },
                new Mogelijkheid { Input = "basiskennis over leefstijlfactoren die somatisch risico inhouden" , Aanvulling = "basiskennis"},
                new Mogelijkheid { Input = "gevorderde kennis over leefstijlfactoren die somatische risico’s inhouden.", Aanvulling = "gevorderde kennis" }
            };

            Aanvulling aanvulling23 = new Aanvulling
            {
                Beschrijving = "Duid de kennisgraad aan die u verwacht aangaande somatische leefstijlfactoren en preventieve maatregelen.",
                Opties = opties23.ToList()
            };

            Competentie comp23 = new Competentie
            {
                Naam = "Preventie- en leefstijlfactoren",
                Verklaring = "De hulpverlener heeft kennis over leefstijlfactoren die somatische risico’s inhouden en kan gericht preventieve acties ondernemen op cliënt- en organisatieniveau.",
                Aanvulling = aanvulling23
            };

            IVraag vraag23 = new VraagRubrics
            {
                VraagStelling = "Duid de stelling aan die het meest bij u past. Ik heb",
                Opties = opties23,
                Competentie = comp23,
                OutputString = "De sollicitant geeft aan dat hij onderstaande kennis heeft over leefstijlfactoren die somatische risico’s inhouden &&"
            };

            comp23.Vraag = vraag23;

            // comp 24
            IList<Mogelijkheid> opties24 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "k heb weinig kennis over de invalshoek van andere disciplines", Aanvulling = "geen of weinig kennis over de invalshoek van andere disciplines nodig", IsSchrapOptie = true },
                new Mogelijkheid { Input = "ik heb enig zicht op de focus van andere beroepsgroepen" , Aanvulling = "enig zicht op de focus van andere beroepsgroepen"},
                new Mogelijkheid { Input = "ik kan benoemen welke kaders en invalshoeken andere disciplines gebruiken.", Aanvulling = " kunnen benoemen welke kaders en invalshoeken andere disciplines gebruiken" }
            };

            Aanvulling aanvulling24 = new Aanvulling
            {
                Beschrijving = "Geef aan hoe gevorderd u het kennisniveau wenst van de sollicitant aangaande andere disciplines. Deze kennis is een noodzakelijke voorwaarde voor interdisciplinair en complementariteit:",
                Opties = opties24.ToList()
            };

            Competentie comp24 = new Competentie
            {
                Naam = "Vakgebied andere professionals",
                Verklaring = "De hulpverlener kent de beroepsspecifieke invalshoeken van andere disciplines en (h)erkent de complementariteit tussen de disciplines actief binnen en buiten de organisatie.",
                Aanvulling = aanvulling24
            };

            IVraag vraag24 = new VraagRubrics
            {
                VraagStelling = "Duid de stelling aan die het meest bij u past",
                Opties = opties24,
                Competentie = comp24,
                OutputString = "De sollicitant geeft aan dat hij onderstaand kennisniveau heeft over de invalshoeken van diverse disciplines &&"
            };

            comp24.Vraag = vraag24;

             // comp 25a
            IList<Mogelijkheid> opties25a = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig", Aanvulling = "minimaal", IsSchrapOptie = true },
                new Mogelijkheid { Input = "matig" , Aanvulling = "matig"},
                new Mogelijkheid { Input = "goed", Aanvulling = "goed" },
                new Mogelijkheid { Input = "itstekend", Aanvulling = "uitstekend"}
            };

            Aanvulling aanvulling25a = new Aanvulling
            {
                Beschrijving = "Welke kennis verwacht u aangaande kritische life-events: Rouwverwerking?",
                Opties = opties25a.ToList()
            };

            Competentie comp25a = new Competentie
            {
                Naam = "Kritische life-events (rouwverwerking)",
                Verklaring = "De hulpverlener heeft kennis over rouwverwerking",
                Aanvulling = aanvulling25a
            };

            IVraag vraag25a = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw kennis in over:",
                Opties = opties25a,
                Competentie = comp25a,
                OutputString = "De sollicitant geeft aan een && kennis te hebben over rouwverwerking"
            };

            comp25a.Vraag = vraag25a;

            // comp 25b
            IList<Mogelijkheid> opties25b = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "weinig", Aanvulling = "minimaal", IsSchrapOptie = true },
                new Mogelijkheid { Input = "matig" , Aanvulling = "matig"},
                new Mogelijkheid { Input = "goed", Aanvulling = "goed" },
                new Mogelijkheid { Input = "itstekend", Aanvulling = "uitstekend"}
            };

            Aanvulling aanvulling25b = new Aanvulling
            {
                Beschrijving = "Welke kennis verwacht u aangaande kritische life-events: traumaverwerking?",
                Opties = opties25b.ToList()
            };

            Competentie comp25b = new Competentie
            {
                Naam = "Kritische life-events (traumaverwerking)",
                Verklaring = "De hulpverlener heeft kennis over traumaverwerking",
                Aanvulling = aanvulling25b
            };

            IVraag vraag25b = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw kennis in over:",
                Opties = opties25b,
                Competentie = comp25b,
                OutputString = "De sollicitant geeft aan een && kennis te hebben over traumaverwerking"
            };

            comp25b.Vraag = vraag25b;

            // comp 26
            IList<Mogelijkheid> opties26 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "gericht opzoeken van wetenschappelijk literatuur is moeilijk", Aanvulling = "niet relevant" },
                new Mogelijkheid { Input = "ik kan gericht opzoeken, maar heb moeilijkheden met het begrijpen van wetenschappelijk vakjargon" , Aanvulling = "gericht opzoeken"},
                new Mogelijkheid { Input = "Ik kan gericht opzoeken en vakjargon begrijpen in functie van de praktijk", Aanvulling = " gericht opzoeken en vakjargon begrijpen in functie van de praktijk" }
            };

            Aanvulling aanvulling26 = new Aanvulling
            {
                Beschrijving = "Geef de kennis die u verwacht van de sollicitant op aangaande het kunnen consulteren van wetenschappelijke bronnen en de interpretatie ervan",
                Opties = opties26.ToList()
            };

            Competentie comp26 = new Competentie
            {
                Naam = "Wetenschappelijke literatuur",
                Verklaring = "De hulpverlener weet waar hij betrouwbare wetenschappelijke literatuur kan consulteren, kan de kwaliteit beoordelen en de inhoud interpreteren.",
                Aanvulling = aanvulling26
            };

            IVraag vraag26 = new VraagRubrics
            {
                VraagStelling = "Geef aan welke uitspraak best bij jou past",
                Opties = opties26,
                Competentie = comp26,
                OutputString = "De sollicitant geeft aan dat hij over volgende competenties beschikt aangaande het opzoeken en consulteren van wetenschappelijke literatuur &&"
            };

            comp26.Vraag = vraag26;

            // comp 27
            IList<Mogelijkheid> opties27 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "alle informatie te delen gezien dit een basisvoorwaarde is voor een goede samenwerking", Aanvulling = "alle informatie delen gezien dit een basisvoorwaarde is om een goede samenwerking te bestendigen" },
                new Mogelijkheid { Input = "om het beroepsgeheim volledig te respecteren en zo weinig mogelijk informatie te delen" , Aanvulling = "zo weinig mogelijk informatie delen gezien dit het beroepsgeheim schendt"},
                new Mogelijkheid { Input = "enkel die informatie te delen die volgens u relevant is voor andere organisatie(s)", Aanvulling = "enkel die informatie delen die relevant is voor andere organisatie(s)" },
                new Mogelijkheid { Input = "enkel die informatie te delen waarover de cliënt expliciet toestemming gegeven heeft om dit te delen", Aanvulling = "enkel die informatie delen waarover de cliënt expliciet toestemming gegeven heeft om dit te delen" }
            };

            Aanvulling aanvulling27 = new Aanvulling
            {
                Beschrijving = "Welke houding verwacht u aangaande het beroepsgeheim binnen samenwerking met andere organisaties?",
                Opties = opties27.ToList()
            };

            Competentie comp27 = new Competentie
            {
                Naam = "Beroepsgeheim ",
                Verklaring = "De hulpverlener heeft kennis van de principes van het gedeeld beroepsgeheim en hanteert het nice to know/need to know principe in samenwerking met andere organisaties.",
                Aanvulling = aanvulling27
            };

            IVraag vraag27 = new VraagRubrics
            {
                VraagStelling = "Geef aan welke uitspraak best bij jou past. In de samenwerking met andere organisaties is het van belang:",
                Opties = opties27,
                Competentie = comp27,
                OutputString = "De sollicitant geeft aan dat hij binnen  de samenwerking met andere organisaties volgende houding prefereert naar inzet van beroepsgeheim toe: && Algemeen wordt aangenomen dat binnen samenwerkingen er enkel die informatie gedeeld wordt waar de cliënt expliciet toestemming heeft gegeven om deze te delen, tenzij het strikt noodzakelijk is voor de verdere opvolging van het te volgen traject."
            };

            comp27.Vraag = vraag27;

            // comp 28a
            IList<Mogelijkheid> opties28a = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Ik heb een beperkte kennis", Aanvulling = "beperkte kennis", IsSchrapOptie = true},
                new Mogelijkheid { Input = "Ik weet naar welke instanties ik cliënten kan doorverwijzen" , Aanvulling = "doorverwijzend"},
                new Mogelijkheid { Input = "Ik heb een goede basiskennis en kan zelf concrete adviezen formuleren", Aanvulling = "basiskennis" },
                new Mogelijkheid { Input = "Ik ben goed op de hoogte en kan zelf gespecialiseerde adviezen formuleren", Aanvulling = "gespecialiseerde kennis" }
            };

            Aanvulling aanvulling28a = new Aanvulling
            {
                Beschrijving = "Over welke minimumkennis over de administratieve rechten van een cliënt dient de toekomstige medewerker te beschikken \nAdministratieve aangelegenheden (vb. juridisch, huisvesting, echtscheiding, rechten en plichten)",
                Opties = opties28a.ToList()
            };

            Competentie comp28a = new Competentie
            {
                Naam = "Rechten (administratief)",
                Verklaring = "De hulpverlener heeft kennis over de administratieve rechten van de cliënt in zijn situatie.",
                Aanvulling = aanvulling28a
            };

            IVraag vraag28a = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw kennis in over: Administratieve aangelegenheden(vb.juridisch, huisvesting, echtscheiding, rechten en plichten)",
                Opties = opties28a,
                Competentie = comp28a,
                OutputString = "De sollicitant geeft aan een && kennis te hebben over administratieve cliëntenrechten"
            };

            comp28a.Vraag = vraag28a;

            // comp 28b
            IList<Mogelijkheid> opties28b = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "Ik heb een beperkte kennis", Aanvulling = "beperkte kennis", IsSchrapOptie = true },
                new Mogelijkheid { Input = "Ik weet naar welke instanties ik cliënten kan doorverwijzen" , Aanvulling = "doorverwijzend"},
                new Mogelijkheid { Input = "Ik heb een goede basiskennis en kan zelf concrete adviezen formuleren", Aanvulling = "basiskennis" },
                new Mogelijkheid { Input = "Ik ben goed op de hoogte en kan zelf gespecialiseerde adviezen formuleren", Aanvulling = "gespecialiseerde kennis" }
            };

            Aanvulling aanvulling28b = new Aanvulling
            {
                Beschrijving = "Over welke minimumkennis over de financiële rechten van een cliënt dient de toekomstige medewerker te beschikken \n Financiële aangelegenheden (vb. uitkeringsgerechtigheid, VAPH, etc.)",
                Opties = opties28b.ToList()
            };

            Competentie comp28b = new Competentie
            {
                Naam = "Rechten (Financieel)",
                Verklaring = "De hulpverlener heeft kennis over de financiële rechten van de cliënt in zijn situatie.",
                Aanvulling = aanvulling28b
            };

            IVraag vraag28b = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw kennis in over: Financiële aangelegenheden (vb. uitkeringsgerechtigheid, VAPH, etc.)",
                Opties = opties28b,
                Competentie = comp28b,
                OutputString = "De sollicitant geeft aan een && kennis te hebben over financiële cliëntenrechten"
            };

            comp28b.Vraag = vraag28b;

            // comp 30
            IList<Mogelijkheid> opties30 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "ik ken daar weinig van", Aanvulling = "niet", IsSchrapOptie = true },
                new Mogelijkheid { Input = "ik kan uitvoerend een aantal zaken opnemen onder supervisie binnen een bestaand project" , Aanvulling = "uitvoerend onder supervisie"},
                new Mogelijkheid { Input = "ik kan autonoom een aantal zaken opnemen binnen een bestaand project", Aanvulling = "autonoom opnemen van een aantal zaken binnen een bestaand projectkader" },
                new Mogelijkheid { Input = "ik kan zelf projecten opstarten en coördineren", Aanvulling = "zelf opstarten en coördineren van projecten" }
            };

            Aanvulling aanvulling30 = new Aanvulling
            {
                Beschrijving = "Geef aan in welke mate uw toekomstige medewerker op de hoogte moet zijn van projectopbouw en -management",
                Opties = opties30.ToList()
            };

            Competentie comp30 = new Competentie
            {
                Naam = "Projectmanagement",
                Verklaring = "De hulpverlener kent de principes van projectmanagement en kan ingeschakeld worden in (een deel van) de uitwerking van een project binnen de organisatie.",
                Aanvulling = aanvulling30
            };

            IVraag vraag30 = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw kennis in over projectopbouw en -aansturing? (vb. uitbouw van agressiebeleid, hobby atelier)",
                Opties = opties30,
                Competentie = comp30,
                OutputString = "De sollicitant geeft aan dat hij over volgende kennis beschikt aangaande projectopbouw en -management &&"
            };

            comp30.Vraag = vraag30;

            // comp 31
            IList<Mogelijkheid> opties31 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "ik heb zelf weinig ervaring met het doorverwijzen van cliënten naar andere instanties", Aanvulling = "minimaal", IsSchrapOptie = true },
                new Mogelijkheid { Input = "ik heb kennis en/of ervaring met doorverwijzen van cliënten naar andere instanties" , Aanvulling = "uitgebreider"}
            };

            Aanvulling aanvulling31 = new Aanvulling
            {
                Beschrijving = "Hoe uitgebreid dient de kennis over de sociale kaart van de sollicitant te zijn",
                Opties = opties31.ToList()
            };

            Competentie comp31 = new Competentie
            {
                Naam = "Gerichte doorverwijzing",
                Verklaring = "De hulpverlener heeft kennis over het vinden van instanties die oplossingen op-maat kunnen bieden voor concrete vragen aangaande noden op diverse levensdomeinen",
                Aanvulling = aanvulling31
            };

            IVraag vraag31 = new VraagRubrics
            {
                VraagStelling = "Hoe contacteert U externe instanties die oplossingen kunnen bieden voor concrete vragen over diverse levensdomeinen (vb. vragen over tijdsbesteding)",
                Opties = opties31,
                Competentie = comp31,
                OutputString = "De sociale kaart dient om in te schatten op welk niveau de sollicitant al dan niet kan doorverwijzen. De sollicitant geeft aan dat hij over volgende kennis beschikt aangaande het gebruik van de sociale kaart && en gebruikt hiervoor volgende middelen $$"
                
            };

            comp31.Vraag = vraag31;

            // comp 34
            IList<Mogelijkheid> opties34 = new List<Mogelijkheid>()
            {
                new Mogelijkheid{ Input = "", Aanvulling = "niet belangrijk", IsSchrapOptie = true},
                new Mogelijkheid { Input = "ik ben goed in het opvolgen van een planning die door anderen is opgesteld", Aanvulling = "dient extern gestuurd te worden" },
                new Mogelijkheid { Input = "ik kan kan mits hulp van collega’s een planning opmaken waar ik me aan houd" , Aanvulling = "kan mits enige sturing van collega’s een planning opmaken"},
                new Mogelijkheid { Input = "kan zelfstandig een planning opmaken en ik houd mij aan de opgemaakte planning", Aanvulling = "kan zelfstandig een planning opmaken en deze strikt opvolgen" },
                new Mogelijkheid { Input = "kan dit zelfstandig opmaken en ik kan flexibel met mijn agenda omgaan", Aanvulling = "maakt zorgvuldige dagplanningen en kan hiermee flexibel omspringen" }
            };

            Aanvulling aanvulling34 = new Aanvulling
            {
                Beschrijving = "Welke competentie ziet u als minimaal naar agendabeheer toe?",
                Opties = opties34.ToList()
            };

            Competentie comp34 = new Competentie
            {
                Naam = "Agendabeheer",
                Verklaring = "De hulpverlener kan zijn agenda en afspraken correct beheren en leeft zijn afspraken na naar cliënten en team toe.",
                Aanvulling = aanvulling34
            };

            IVraag vraag34 = new VraagRubrics
            {
                VraagStelling = "Hoe schat u uw vaardigheden aangaande agendabeheer in?",
                Opties = opties34,
                Competentie = comp34,
                OutputString = "De sollicitant geeft onderstaand aan wat betreft zijn competentie tot agendabeheer: &&"
            };

            comp34.Vraag = vraag34;

            // comp 35
            IList<Mogelijkheid> opties35 = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "", Aanvulling = "", IsSchrapOptie = true },
                new Mogelijkheid { Input = "" , Aanvulling = ""},
                new Mogelijkheid { Input = "", Aanvulling = "" },
                new Mogelijkheid { Input = "", Aanvulling = "" }
            };

            Aanvulling aanvulling35 = new Aanvulling
            {
                Beschrijving = "",
                Opties = opties35.ToList()
            };

            Competentie comp35 = new Competentie
            {
                Naam = "",
                Verklaring = "",
                Aanvulling = aanvulling35
            };

            IVraag vraag35 = new VraagRubrics
            {
                VraagStelling = "",
                Opties = opties35,
                Competentie = comp35,
                OutputString = ""
            };

            comp35.Vraag = vraag35;


            // temp
            IList<Mogelijkheid> opties = new List<Mogelijkheid>()
            {
                new Mogelijkheid { Input = "", Aanvulling = "", IsSchrapOptie = true },
                new Mogelijkheid { Input = "" , Aanvulling = ""},
                new Mogelijkheid { Input = "", Aanvulling = "" },
                new Mogelijkheid { Input = "", Aanvulling = "" }
            };

            Aanvulling aanvulling = new Aanvulling
            {
                Beschrijving = "",
                Opties = opties.ToList()
            };

            Competentie comp = new Competentie
            {
                Naam = "",
                Verklaring = "",
                Aanvulling = aanvulling
            };

            IVraag vraag = new VraagRubrics
            {
                VraagStelling = "",
                Opties = opties,
                Competentie = comp,
                OutputString = ""
            };

            comp.Vraag = vraag;


            // rustig

            ICollection <Competentie> competenties = new List<Competentie>();
            competenties.Add(comp1);
            competenties.Add(comp3);
            competenties.Add(comp12);
            competenties.Add(comp15);
            competenties.Add(comp42);
            competenties.Add(comp43);
            competenties.Add(comp45);
            competenties.Add(comp46);
            competenties.Add(comp49);
            competenties.Add(comp60);
            competenties.Add(comp73);
            competenties.Add(comp75);
            competenties.Add(comp81);
            competenties.Add(comp10);
            competenties.Add(comp32);
            competenties.Add(comp41);
            competenties.Add(comp51);
            competenties.Add(comp56);
            competenties.Add(comp69);
            competenties.Add(comp76);
            competenties.Add(comp79);
            competenties.Add(comp8);
            competenties.Add(comp9);
            competenties.Add(comp13);
            competenties.Add(comp16);
            competenties.Add(comp18);
            competenties.Add(comp19);
            competenties.Add(comp20);
            competenties.Add(comp21);
            competenties.Add(comp22);
            competenties.Add(comp23);
            competenties.Add(comp24);
            competenties.Add(comp25a);
            competenties.Add(comp25b);
            competenties.Add(comp26);
            competenties.Add(comp27);
            competenties.Add(comp28a);
            competenties.Add(comp28b);
            competenties.Add(comp30);
            competenties.Add(comp31);
            competenties.Add(comp34);
            competenties.Add(comp35);

            vac1.AddCompetenties(competenties);
            vac3.AddCompetenties(competenties);

            // ingevulde vacature
            //vac1.CompetentiesLijst.SingleOrDefault(v => v.CompetentieId.Equals(vraag13)).GeselecteerdeOptie = opties13.FirstOrDefault();
            IList<Response> responses = new List<Response>()
            {
                new Response { Vraag = vraag1, OptieKeuze = optie12, Aanvulling = "Dit is een aanvulling op vraag over Boris"},
                new Response { Vraag = vraag3, OptieKeuze = optie14, Aanvulling = "Dit is een aanvulling op een random vraag"},
                new Response { Vraag = vraag73, OptieKeuze = opties3.FirstOrDefault(), Aanvulling = "ben benieuwd of deze werkt"},
                new Response { Vraag = vraag13, Aanvulling = "hier zijn we dan weer voor nog een vraag"}
            };

            IngevuldeVacature ingevuldeVac1 = new IngevuldeVacature { Vacature = vac1, Responses = responses};

            // add to context
            context.Competenties.Add(comp1);
            context.Competenties.Add(comp3);
            context.Competenties.Add(comp12);
            context.Competenties.Add(comp15);
            context.Competenties.Add(comp42);
            context.Competenties.Add(comp43);
            context.Competenties.Add(comp45);
            context.Competenties.Add(comp46);
            context.Competenties.Add(comp49);
            context.Competenties.Add(comp60);
            context.Competenties.Add(comp73);
            context.Competenties.Add(comp75);
            context.Competenties.Add(comp81);
            context.Competenties.Add(comp10);
            context.Competenties.Add(comp32);
            context.Competenties.Add(comp41);
            context.Competenties.Add(comp51);
            context.Competenties.Add(comp56);
            context.Competenties.Add(comp69);
            context.Competenties.Add(comp76);
            context.Competenties.Add(comp79);
            context.Competenties.Add(comp8);
            context.Competenties.Add(comp9);
            context.Competenties.Add(comp13);
            context.Competenties.Add(comp16);
            context.Competenties.Add(comp18);
            context.Competenties.Add(comp19);
            context.Competenties.Add(comp20);
            context.Competenties.Add(comp21);
            context.Competenties.Add(comp22);
            context.Competenties.Add(comp23);
            context.Competenties.Add(comp24);
            context.Competenties.Add(comp25a);
            context.Competenties.Add(comp25b);
            context.Competenties.Add(comp26);
            context.Competenties.Add(comp27);
            context.Competenties.Add(comp28a);
            context.Competenties.Add(comp28b);
            context.Competenties.Add(comp30);
            context.Competenties.Add(comp31);
            context.Competenties.Add(comp34);
            context.Competenties.Add(comp35);

            context.Vragen.Add(vraag1);
            context.Vragen.Add(vraag3);
            context.Vragen.Add(vraag73);
            context.Vragen.Add(vraag13);

            context.Vacature.Add(vac1);
            context.Vacature.Add(vac2);
            context.Vacature.Add(vac3);

            context.IngevuldeVacatures.Add(ingevuldeVac1);

            context.SaveChanges();
        }

        
    }
}