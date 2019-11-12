using MVC_League.Entities;
using MVC_League.Models.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace MVC_League.Controllers
{
    public class ResultController : Controller
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
        private LeagueBl _leagueBl = null;
        private FixtureBl _fixtureBl = null;
        private MatchBl _matchBl = null;

        public ResultController()
        {
            _leagueBl = new LeagueBl();
            _fixtureBl = new FixtureBl();
            _matchBl = new MatchBl();
        }

        // GET: Result
        public ActionResult Index()
        {            
            return View();
        }

        // GET: Result
        public ActionResult Fixtures()
        {
            ViewBag.Leagues = _leagueBl.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult AddFixture(Fixture fixture, List<Match> matches)
        {
            try
            {
                var _fixture = _fixtureBl.Add(fixture);
                _matchBl.AddMany(_fixture.Id, matches);

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, Error.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdatePositions(List<Positions> positions, Fixture fixture, List<Match> matches)
        {
            try
            {
                var _fixture = _fixtureBl.Add(fixture);
                _matchBl.AddMany(_fixture.Id, matches);
                _fixtureBl.UpdatePositions(positions);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, Error.Message);
            }
        }

        [HttpPost]
        public JsonResult GetFixtures(Dictionary<string,int> dict)
        {
            var data = _fixtureBl.GetByNFixtureAndSeason(dict);
            //string jsonResult = JsonConvert.SerializeObject(data, Formatting.None, settings);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public HttpStatusCodeResult CreateCSVFile(string content)
        {
            string path = @"E:\temp\Positions.csv";
            Byte[] info = null;

            try
            {
                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = System.IO.File.Create(path))
                {
                    info = new UTF8Encoding(true).GetBytes(content);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }


                // Open the stream and read it back.
                //using (StreamReader sr = System.IO.File.OpenText(path))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
                //new FileContentResult(info, "application/csv;charset=utf-8");
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //try
            //{
            //    var filename = "Positions.csv";
            //    var miCSV = new Jitbit.Utils.CsvExport();

            //    var fixtures= content.Split(';');
            //    miCSV.AddRows(fixtures);
            //    //foreach (var fixture in fixtures)
            //    //{
            //    //    miCSV.AddRow();
            //    //    miCSV[""] = fixture;
            //    //}

            //    miCSV.ExportToFile(@"D:\"+filename);
            //    return File(miCSV.ExportToBytes(), "application/csv;charset=utf-8", filename);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    return null;
            //}
        }

        [HttpPost]
        public JsonResult GetAllFixturesByLeague(Fixture fixture)
        {
            var fixtures = _fixtureBl.GetAllFixturesByLeague(fixture);
            return Json(fixtures, JsonRequestBehavior.AllowGet);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            ViewBag.LeaguesWithTeams = _leagueBl.GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult GetNextFixture(Fixture fixture)
        {
            var data = _matchBl.GetByNFixture(fixture);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddNextFixture(Fixture fixture, List<Match> matches)
        {
            try
            {
                var _fixture = _fixtureBl.Add(fixture);
                _matchBl.AddMany(_fixture.Id, matches);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, Error.Message);
            }
        }

        public ActionResult Competitions()
        {
            return View();
        }
    }
}
