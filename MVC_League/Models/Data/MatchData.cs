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

        // Obtiene todas las fechas por el numero de la fecha
        public List<Match> GetById(int fixtureId)
        {
            return db.Matches.Where(w => w.FixtureId == fixtureId).ToList();
        }
    }
}