using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_League.Entities;
using System.Data.Entity.Migrations;

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
            //db.Matches.AddRange(matches);
            //db.SaveChanges();

            try
            {
                foreach (var match in matches)
                {
                    db.Matches.AddOrUpdate(u => u.Id, match);
                }
                db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Error.Message = "Error al agregar o actualizar partidos: " + ex.Message;
            }
        }

        // Obtiene todas las fechas por el numero de la fecha
        public List<Match> GetByFixtureId(int fixtureId)
        {
            return db.Matches.Where(w => w.FixtureId == fixtureId).ToList();
        }

        public void Add(Match match)
        {
            db.Matches.Add(match);
            db.SaveChanges();
        }
    }
}