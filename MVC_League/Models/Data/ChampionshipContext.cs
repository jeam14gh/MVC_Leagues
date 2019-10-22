using MVC_League.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_League.Models.Data
{
    public class ChampionshipContext: DbContext
    {
        public ChampionshipContext() : base ("ChampionshipConnection")
        {

        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<MVC_League.Entities.Match> Matches { get; set; }
        public DbSet<Positions> Positions { get; set; }
    }
}