using MVC_League.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_League.Models.Data
{
    public class LeagueData
    {
        private ChampionshipContext db = null;
        public LeagueData()
        {
            db = new ChampionshipContext();
        }

        public League Add(League league)
        {
            db.Leagues.Add(league);
            db.SaveChanges();
            return league;
        }

        public List<League> GetAll()
        {
            return db.Leagues.ToList();
        }

        public League GetById(int id)
        {
            return db.Leagues.FirstOrDefault(f => f.Id == id);
        }

        public void Update(League league)
        {
            db.Leagues.AddOrUpdate(u=>u.Id, league);
            db.SaveChanges();
        }
    }
}