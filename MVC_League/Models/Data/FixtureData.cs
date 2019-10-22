﻿using MVC_League.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity.Migrations;

namespace MVC_League.Models.Data
{
    public class FixtureData
    {
        private ChampionshipContext db = null;
        public FixtureData()
        {
            db = new ChampionshipContext();
        }
        
        public async Task UpdatePositions(List<Positions> positions)
        {
            try
            {
                foreach (var position in positions)
                {
                    db.Positions.AddOrUpdate(u => u.TeamId, position);
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Error.Message = "Error in UpdatePositions method: " + ex.Message;
            }

        }

        public List<Positions> GetPositionsByLeagueId(int id)
        {
            return db.Positions.Where(w => w.LeagueId == id).OrderBy(o => o.Pos).ToList();
        }

        public Fixture Add(Fixture fixture)
        {
            try
            {
                db.Fixtures.Add(fixture);
                db.SaveChanges();
                return fixture;
            }
            catch (Exception ex)
            {
                Error.Message ="Error in Add Fixture method: " +  ex.Message;
                return null;
            }
        }

        public List<Fixture> GetByLeagueAndSeason(int leagueid, int season)
        {
            try
            {  
                return db.Fixtures.Where(w => w.LeagueId == leagueid && w.Season == season).ToList();
            }
            catch (Exception ex)
            {
                var msj = ex.Message;
                return new List<Fixture>();
            }
        }
    }
}