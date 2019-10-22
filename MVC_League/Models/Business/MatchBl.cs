using MVC_League.Entities;
using MVC_League.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_League.Models.Business
{
    public class MatchBl
    {
        private MatchData _matchData = null;
        public MatchBl()
        {
            _matchData = new MatchData();
        }

        public void AddMany(int fixtureId, List<Match> matches)
        {
            foreach (var match in matches)
            {
                match.FixtureId = fixtureId;
            }

            _matchData.AddMany(matches);
        }
    }
}