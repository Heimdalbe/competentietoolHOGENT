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


            IngevuldeVacature vac = _ingevuldeVacatureRepository.GetBy(id);
            ICollection<RapportViewModel> models = new List<RapportViewModel>();
            foreach (Response r in vac.responses)
            {
                RapportViewModel rvm = new RapportViewModel();
                rvm.CompetentieNaam = r.Vraag.Competentie.Naam;
                rvm.VraagStelling = r.Vraag.VraagStelling;
                rvm.OptieKeuze = r.OptieKeuze.Output;
                rvm.Vignet = r.Vraag.Vignet.Beschrijving;
                rvm.Redenering = r.Aanvulling;

                /* hier moet nog gezorgd worden dat de rubric kan vergeleken worden (dus soli en bedrijf antwoorden matchen)
                if (r.Vraag.type.Equals(VraagType.RUBRIC))
                {
                    int result = r.OptieKeuze.Equals(r.Aanvulling) ? 1 : 0;
                    if (r.Vraag.Competentie.type.Equals(CompetentieType.GRONDHOUDING))
                    {
                        lijst1.Add(result);
                    }
                    if (r.Vraag.Competentie.type.Equals(CompetentieType.KENNIS))
                    {
                        lijst2.Add(result);
                    }
                    if (r.Vraag.Competentie.type.Equals(CompetentieType.VAARDIGHEDEN))
                    {
                        lijst3.Add(result);
                    }
                }
                */
                models.Add(rvm);
                


            }
            ICollection<Group<string, RapportViewModel>> groups = new List<Group<string, RapportViewModel>>();
            var results = models.GroupBy(m => m.Vignet).ToList();


            /*
             Hier moeten de opties van de rubric worden berekend. Als opties gelijk zijn dan 1, anders 0
             
             */

            lijst1.Add(1); lijst1.Add(1); lijst1.Add(0); lijst1.Add(1); lijst1.Add(0); lijst1.Add(1);
            lijst2.Add(0); lijst2.Add(0); lijst2.Add(1); lijst2.Add(0); lijst2.Add(0); lijst2.Add(1); lijst2.Add(0);
            lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(1); lijst3.Add(0); lijst3.Add(0); lijst3.Add(0);
            FixDonutDiagrammen(lijst1, lijst2, lijst3);


            foreach (var item in results)
            {
                groups.Add(new Group<string, RapportViewModel> { Key = item.Key, Values = item.ToList() });
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
            dataPoints1.Add(new DataPoint("", percentage1));
            dataPoints1.Add(new DataPoint("", 100-percentage1));
            ViewBag.Percentage1 = percentage1 + "%";
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);

            double totaal2 = 0;
            foreach (var i in kennisRubrics)
            {
                totaal2 += i;
            }
            double percentage2 = Math.Round((totaal2 / kennisRubrics.Count)*100, 1);
            dataPoints2.Add(new DataPoint("", percentage2));
            dataPoints2.Add(new DataPoint("", 100 - percentage2));
            ViewBag.Percentage2 = percentage2 + "%";
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

            double totaal3 = 0;
            foreach (var i in vaardighedenRubrics)
            {
                totaal3 += i;
            }
            double percentage3 = Math.Round((totaal3 / vaardighedenRubrics.Count)*100, 1);
            dataPoints3.Add(new DataPoint("", percentage3));
            dataPoints3.Add(new DataPoint("", 100 - percentage3));
            ViewBag.Percentage3 = percentage3 + "%";
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);


        }

    }
}