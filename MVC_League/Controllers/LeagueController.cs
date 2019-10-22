using MVC_League.Entities;
using MVC_League.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_League.Controllers
{
    public class LeagueController : Controller
    {
        private LeagueBl _leagueBl = null;
        public LeagueController()
        {
            _leagueBl = new LeagueBl();
        }

        // GET: League
        public ActionResult Index()
        {
            var leagues = _leagueBl.GetAll();
            return View(leagues);
        }
        
        // POST: League/Create
        [HttpPost]
        public JsonResult Create(League league)
        {            
            if (ModelState.IsValid)
            {
                var model =_leagueBl.Add(league);
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return Json(null);
        }        

        // POST: League/Edit/5
        [HttpPost]
        public ActionResult Edit(League league)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _leagueBl.Update(league);                    
                }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
    }
}
