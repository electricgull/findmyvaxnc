using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using findmyvaxnc.Models;
using System.Web;

namespace findmyvaxnc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<LocationModel> locations = new List<LocationModel>();
            List<TestingModel> testingSites = new List<TestingModel>();
            ModelCollection returnView = new ModelCollection();
            var filepath = "docs/locations.csv";
            var tFilepath = "docs/testing.csv";

            if (System.IO.File.Exists(filepath))
            {


                using (var reader = new StreamReader(@filepath))
                {
                    var header = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        if (values.Length == 9)
                        {
                            locations.Add(new LocationModel
                            {
                                County = values[0],
                                Name = values[1],
                                Address = values[2],
                                Phone = values[3],
                                Hours = values[4],
                                AppointmentType = values[5],
                                WebsiteName = values[6],
                                Website = values[7],
                                Verified = values[8],
                            });
                        }

                    }
                }
                returnView.locationView = locations;
            }


            if (System.IO.File.Exists(tFilepath))
            {
                using (var reader = new StreamReader(tFilepath))
                {
                    var header = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        if (values.Length == 12)
                        {
                            testingSites.Add(new TestingModel
                            {
                                County = values[0],
                                Name = values[1],
                                Address = values[2],
                                Phone = values[3],
                                TestType = values[4],
                                ResultResponse = values[5],
                                AgeRequirement = values[6],
                                ScreeningRequirement = values[7],
                                AppointmentType = values[8],
                                WebsiteName = values[9],
                                Website = values[10],
                                Verified = values[11]
                            });
                        }
                    }
                }
                returnView.testView = testingSites;
            }

            return View(returnView);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
