using MVC_League.Entities;
using MVC_League.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_League.Models.Business
{

    public class LeagueBl
    {
        private LeagueData _leagueData = null;
        public LeagueBl()
        {
            _leagueData = new LeagueData();
        }

        public League Add(League league)
        {
            return _leagueData.Add(league);
        }

        public List<League> GetAll()
        {
            return _leagueData.GetAll(); // _leagueData.GetAll(true);
        }

        public List<SelectListItem> GetListItems(){
            var leagues = _leagueData.GetAll();
            var items = new List<SelectListItem>();
            foreach (var l in leagues)
            {
                items.Add(new SelectListItem() 
                {
                    Text=l.Name,
                    Value= l.Id.ToString()
                });
            }

            return items;
        }

        public void Update(League league)
        {
            _leagueData.Update(league);
        }
    }
}