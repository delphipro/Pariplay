using System.Collections.Generic;
using System.Linq;
using Pariplay.DataAccessLayer.Abstraction.Repository;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.DataAccessLayer.DbContextConfig;
using Pariplay.Models;

namespace Pariplay.DataAccessLayer.Repository
{
    public class MatchRepository: IMatchRepository
    {
        private readonly PariplayDbContext _dbcontext;

        public MatchRepository(PariplayDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void CreateMatch(MatchDTO match)
        {
            _dbcontext.Match.Add(match);
        }

        public void UpdateMatch(MatchDTO match)
        {
            var record = _dbcontext.Match.FirstOrDefault(x => x.Id == match.Id);
            if(record == null) return;

            record.Host = match.Host;
            record.Visitor = match.Visitor;
            record.HostId = match.HostId;
            record.VisitorId = match.VisitorId;
            record.TeamHostResult = match.TeamHostResult;
            record.TeamVisitorResult = match.TeamVisitorResult;

        }

        public Match GetMatchById(int matchId)
        {
            var data = _dbcontext.Match.FirstOrDefault(x => x.Id == matchId);
            return new Match(data, true);
        }

        public ICollection<Match> GetAllMatchesByTeam(int teamId)
        {
            var data = _dbcontext.Match.Where(x => x.HostId == teamId || x.VisitorId == teamId).ToList();
            return data.Select(x => new Match(x, x.HostId == teamId)).ToList();
        }
    }
}
