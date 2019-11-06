using MVC_League.Models.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_League.Controllers
{
    public class HomeController : Controller
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        private LeagueBl _leagueBl = null;
        private TeamBl _teamBl = null;
        private FixtureBl _fixtureBl = null;

        public HomeController()
        {
            _teamBl = new TeamBl();
            _leagueBl = new LeagueBl();
            _fixtureBl = new FixtureBl();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLeaguesTeams()
        {
            var leagues = _leagueBl.GetAll();
            var teams = _teamBl.GetAll();
            //string jsonResult = JsonConvert.SerializeObject(data, Formatting.None, settings);
            return Json(new { Leagues= leagues, Teams= teams}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllLeagues()
        {
            var data = _leagueBl.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPositionsByLeagueId(int id, int season)
        {
            var data = _fixtureBl.GetPositionsByLeagueId(id);
            var currentFixture = _fixtureBl.GetGreaterByLeague(id, season);

            return Json(new { CurrentFixture = currentFixture, Positions = data }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}