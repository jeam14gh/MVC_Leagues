using MVC_League.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;


namespace MVC_League.Models.Data
{
    public class TeamData
    {
        private ChampionshipContext db = null;
        public TeamData()
        {
            db = new ChampionshipContext();
        }

        public Team Add(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return team;
        }

        public List<Team> GetAll()
        {
            return db.Teams.ToList();
        }


        public List<Team> GetByLeagueId(int id)
        {
            return db.Teams.Where(i => i.LeagueId == id).ToList();
        }

        public void Update(Team team)
        {
            db.Teams.AddOrUpdate(u => u.Id, team);
            db.SaveChanges();
        }
    }
}