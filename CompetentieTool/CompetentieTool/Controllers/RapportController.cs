using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Data.Repositories;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompetentieTool.Controllers
{
    public class RapportController : Controller
    {
        
        private readonly IIngevuldeVacatureRepository _ingevuldeVacatureRepository;

        public RapportController(IIngevuldeVacatureRepository ingevuldeVacatureRepository)
        {
            _ingevuldeVacatureRepository = ingevuldeVacatureRepository;
        }
        public IActionResult Index(String id)
        {

            List<Double> lijst1 = new List<double>();
            List<Double> lijst2 = new List<double>();
            List<Double> lijst3 = new List<double>();

            List<String> comp1 = new List<string>();
            List<String> comp2 = new List<string>();
            List<String> comp3 = new List<string>();



            IngevuldeVacature vac = _ingevuldeVacatureRepository.GetBy(id);
            ICollection<RapportViewModel> models = new List<RapportViewModel>();
            ViewBag.naam = vac.VoornaamSollicitant + " " + vac.AchternaamSollicitant;
            ViewBag.telefoon = vac.TelefoonSollicitant;
            ViewBag.mail = vac.EmailSollicitant;
            ViewBag.title = vac.Vacature.Functie;
            ViewBag.desc = vac.Vacature.Beschrijving;
            ViewBag.datum = vac.DatumIngevuld;
            foreach (ResponseGroup rg in vac.ResponseGroup)
            {
                RapportViewModel rvm = new RapportViewModel();
                rvm.CompetentieNaam = rg.Competentie.Naam;
                rvm.Verklaring = rg.Competentie.Verklaring;
                rvm.CompetentieType = rg.Competentie.Type;
                if (rg.Competentie.Vignet!= null)
                {
                    rvm.Vignet = rg.Competentie.Vignet.Naam;
                }
                else
                {
                    rvm.Vignet = "LEEG";
                }

                foreach (Response r in rg.Responses)
                {
                    AntwoordViewModel avm = new AntwoordViewModel();
                    
                    avm.VraagStelling = r.Vraag.VraagStelling;
                    
                    avm.Antwoord = r.Vraag.OutputString;
                    if (r.OpenAntwoord != null && r.OpenAntwoord.Trim().Length != 0)
                    {
                        avm.Antwoord = avm.Antwoord.Replace("$$", r.OpenAntwoord);
                    }
                    else
                    {
                        if (r.OptieKeuze != null)
                        {
                            if (r.OptieKeuze.Output != null && r.OptieKeuze.Output.Trim().Length != 0)
                            {
                                avm.Antwoord = avm.Antwoord.Replace("$$", r.OptieKeuze.Output);
                            }
                            else
                            {

                                avm.Antwoord = avm.Antwoord.Replace("$$", r.OptieKeuze.Input);
                            }
                            
                        }
                        else
                        {
                            avm.Antwoord = avm.Antwoord = "LEEG";
                        }
                           
                    }
                    

                    /* hier moet nog gezorgd worden dat de rubric kan vergeleken worden (dus soli en bedrijf antwoorden matchen)*/
                    if (r.Vraag.type.Equals(VraagType.RUBRIC))
                    {

                        int result;
                        VacatureCompetentie temp = vac.Vacature.CompetentiesLijst.Where(c => c.Competentie.Vragen.OrderBy(co => co.VraagVolgorde).FirstOrDefault().Id.Equals(r.Vraag.Id)).FirstOrDefault();

                        if (r.OptieKeuze == null || temp.GeselecteerdeOptie == null)
                        {
                            result = 0;
                        }
                        else
                        {

                            result = r.OptieKeuze.Score <= temp.GeselecteerdeOptie.Score ? 1 : 0;
                        }

                        if (r.Vraag.Competentie.Type.Equals(CompetentieType.GRONDHOUDING))
                        {
                            lijst1.Add(result);
                            comp1.Add(r.Vraag.Competentie.Naam);
                        }
                        if (r.Vraag.Competentie.Type.Equals(CompetentieType.KENNIS))
                        {
                            lijst2.Add(result);
                            comp2.Add(r.Vraag.Competentie.Naam);
                        }
                        if (r.Vraag.Competentie.Type.Equals(CompetentieType.VAARDIGHEDEN))
                        {
                            lijst3.Add(result);
                            comp3.Add(r.Vraag.Competentie.Naam);
                        }
                    }
                    ViewBag.comp1 = comp1;
                    ViewBag.comp2 = comp2;
                    ViewBag.comp3 = comp3;
                    rvm.vms.Add(avm);
                }
                models.Add(rvm);
            }
            ICollection<Group<string, RapportViewModel>> groups = new List<Group<string, RapportViewModel>>();
            var results = models.GroupBy(m => m.CompetentieType).ToList();


            /*
             Hier moeten de opties van de rubric worden berekend. Als opties gelijk zijn dan 1, anders 0
             
             */
             /*
            lijst1.Add(1); lijst1.Add(1); lijst1.Add(0); lijst1.Add(1); lijst1.Add(0); lijst1.Add(1);
            lijst2.Add(0); lijst2.Add(0); lijst2.Add(1); lijst2.Add(0); lijst2.Add(0); lijst2.Add(1); lijst2.Add(0);
            lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(0); lijst3.Add(0); lijst3.Add(0);*/
            FixDonutDiagrammen(lijst1, lijst2, lijst3);


            foreach (var item in results)
            {
                groups.Add(new Group<string, RapportViewModel> { Key = item.Key.ToString(), Values = item.ToList() });
            }
            return View(groups);
        }

        public void FixDonutDiagrammen(List<Double> grondhoudingRubrics, List<Double> kennisRubrics, List<Double> vaardighedenRubrics)
        {
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();


            
            double totaal = 0;
            foreach (var i in grondhoudingRubrics)
            {
                totaal += i;
            }
            double percentage1 = Math.Round((totaal / grondhoudingRubrics.Count)*100, 1);
            if (!Double.IsNaN(percentage1))
            {
                dataPoints1.Add(new DataPoint("", percentage1));
                dataPoints1.Add(new DataPoint("", 100 - percentage1));
                ViewBag.Percentage1 = percentage1 + "%";
                ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            }
            else
            {
                dataPoints1.Add(new DataPoint("", 0));
                ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
                ViewBag.Percentage1 = "Niet ondervraagd";
            }


            double totaal2 = 0;
            foreach (var i in kennisRubrics)
            {
                totaal2 += i;
            }
            double percentage2 = Math.Round((totaal2 / kennisRubrics.Count)*100, 1);
            if (!Double.IsNaN(percentage2))
            {
                dataPoints2.Add(new DataPoint("", percentage2));
                dataPoints2.Add(new DataPoint("", 100 - percentage2));
                ViewBag.Percentage2 = percentage2 + "%";
                ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            }
            else
            {
                ViewBag.Percentage2 = "Niet ondervraagd";
                dataPoints2.Add(new DataPoint("", 0));
                ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            }
            double totaal3 = 0;
            foreach (var i in vaardighedenRubrics)
            {
                totaal3 += i;
            }

            double percentage3 = Math.Round((totaal3 / vaardighedenRubrics.Count) * 100, 1);
            if (!Double.IsNaN(percentage3))
            {
                dataPoints3.Add(new DataPoint("", percentage3));
                dataPoints3.Add(new DataPoint("", 100 - percentage3));
                ViewBag.Percentage3 = percentage3 + "%";
                ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);
            }
            else
            {
                dataPoints3.Add(new DataPoint("", 0));
                ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);
                ViewBag.Percentage3 = "Niet ondervraagd";
            }


        }

    }
}