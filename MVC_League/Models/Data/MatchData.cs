using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_League.Entities;

namespace MVC_League.Models.Data
{
    public class MatchData
    {
        private ChampionshipContext db = null;
        public MatchData()
        {
            db = new ChampionshipContext();
        }

        public void AddMany(List<Match> matches)
        {
            db.Matches.AddRange(matches);
            db.SaveChanges();
        }

        public List<Match> GetById(int id)
        {
            return db.Matches.Where(w => w.FixtureId == id).ToList();
        }
    }
}