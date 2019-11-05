﻿using MVC_League.Entities;
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
        private FixtureBl _fixtreBl = null;

        public MatchBl()
        {
            _matchData = new MatchData();
            _fixtreBl = new FixtureBl();
        }

        public void AddMany(int fixtureId, List<Match> matches)
        {
            foreach (var match in matches)
            {
                match.FixtureId = fixtureId;
            }

            _matchData.AddMany(matches);
        }

        public List<Match> GetByNFixture(Fixture fixture)
        {
            var _fixture = _fixtreBl.GetByNFixture(fixture);
            if (_fixture != null)
            {
                return _matchData.GetByFixtureId(_fixture.Id);
            }
            else
            {
                return new List<Match>();
            }
        }

        /// <summary>
        /// Agrega los partidos siguentes de una fecha o aplazados
        /// </summary>
        public void AddNext(int fixtureId, List<Match> nextMatches)
        {
            var matchesSaved = _matchData.GetByFixtureId(fixtureId);
            foreach (var m in nextMatches)
            {
                var match = matchesSaved.FirstOrDefault(f => f.TeamIdLocal == m.TeamIdLocal && f.TeamIdVisitor == m.TeamIdVisitor);
                if (match == null)
                {
                    m.FixtureId = fixtureId;
                    _matchData.Add(m);
                }
            }
            
        }
    }
}