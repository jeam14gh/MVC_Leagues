using MVC_League.Entities;
using MVC_League.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC_League.Models.Business
{
    public class FixtureBl
    {
        private FixtureData _fixtureData = null;
        private MatchData _matchesData = null;
        public FixtureBl()
        {
            _fixtureData = new FixtureData();
            _matchesData = new MatchData();
        }

        public void UpdatePositions(List<Positions> positions)
        {
             _fixtureData.UpdatePositions(positions).GetAwaiter();
        }

        public List<Positions> GetPositionsByLeagueId(int id)
        {
            return _fixtureData.GetPositionsByLeagueId(id);
        }

        public Fixture Add(Fixture fixture)
        {
            var _fixture = _fixtureData.GetByNFixture(fixture.NFixture);
            if (_fixture != null)
            {
                return _fixture;
            }
            return _fixtureData.Add(fixture);
        }

        public List<Fixture> GetByNFixtureAndSeason(Dictionary<string, int> dict)
        {
            int fixtureto = dict["NFixtureTo"];
            int season = dict["Season"];
            int leagueid = dict["LeagueId"];

            var fixtures= _fixtureData.GetByLeagueAndSeason(leagueid, season);
            foreach (var f in fixtures)
            {
                var matches = _matchesData.GetById(f.Id);
                f.Matches = matches;
            }
            return fixtures.Where(w => w.NFixture <= fixtureto).OrderBy(o=>o.NFixture).ToList();
        }

        public List<Fixture> GetAllFixturesByLeague(Fixture fixture)
        {
            var fixtures= _fixtureData.GetByLeagueAndSeason(fixture.LeagueId, fixture.Season).OrderBy(o => o.NFixture).ToList();
            foreach (var f in fixtures)
            {
                var matches = _matchesData.GetById(f.Id);
                f.Matches = matches;
            }

            return fixtures;
        }
    }
}