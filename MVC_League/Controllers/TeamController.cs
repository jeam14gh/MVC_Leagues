using MVC_League.Entities;
using MVC_League.Models.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_League.Controllers
{
    public class TeamController : Controller
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
        private LeagueBl _leagueBl = null;
        private TeamBl _teamBl = null;

        public TeamController()
        {
            _teamBl = new TeamBl();
            _leagueBl = new LeagueBl();
        }

        // GET: Team
        public ActionResult Index()
        {
            var leagues = _leagueBl.GetAll();
            ViewBag.Leagues = leagues;
            var teams = _teamBl.GetAll();
            return View(teams);
        }        

        // POST: Team/Create
        [HttpPost]
        public JsonResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                var model= _teamBl.Add(team);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            
            return null;
        }
        
        [HttpPost]
        public ActionResult Edit(Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _teamBl.Update(team);
                }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "ModelState: " + ModelState.IsValid);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }     

        [HttpGet]
        public JsonResult GetByLeagueId(int id)
        {
            var data = _teamBl.GetByLeagueId(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }        
    }
}
