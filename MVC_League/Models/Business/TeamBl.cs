using MVC_League.Entities;
using MVC_League.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_League.Models.Business
{
    public class TeamBl
    {
        private TeamData _teamData = null;
        public TeamBl()
        {
            _teamData = new TeamData();
        }

        public Team Add(Team team)
        {
            return _teamData.Add(team);
        }

        public List<Team> GetAll()
        {
            return _teamData.GetAll();
        }

        public List<Team> GetByLeagueId(int id)
        {
            return _teamData.GetByLeagueId(id);
        }

        public void Update(Team team)
        {
            _teamData.Update(team);
        }
    }
}