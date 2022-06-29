using System.Collections.Generic;
using System.Linq;
using Pariplay.DataAccessLayer.Abstraction.Repository;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.DataAccessLayer.DbContextConfig;
using Pariplay.Models;

namespace Pariplay.DataAccessLayer.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly PariplayDbContext _dbcontext;

        public TeamRepository(PariplayDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void CreateTeam(TeamDTO team)
        {
            _dbcontext.Team.Add(team);
        }

        public void UpdateTeam(TeamDTO team)
        {
            var record = _dbcontext.Team.FirstOrDefault(x => x.Id == team.Id);
            if (record == null) return;
            record.Name = team.Name;
        }

        public Team GetTeamById(int teamId)
        {
            var record = _dbcontext.Team.FirstOrDefault(x => x.Id == teamId);
            if (record == null) return null;
            return new Team(record);
        }

        public TeamWithMatches GetTeamWithMatchesByTeamId(int teamId)
        {
            var record = _dbcontext.Team.FirstOrDefault(x => x.Id == teamId);
            if(record == null) return null;
            var result = new TeamWithMatches {Name = record.Name};
            var matches = _dbcontext.Match.Where(x => x.HostId == teamId || x.VisitorId == teamId).ToList();
            result.Matches = matches.Select(x => new Match(x, x.HostId == teamId)).ToList();
            return result;
        }

        public ICollection<Team> GetAllTeams()
        {
            var result = _dbcontext.Team.ToList();
            return result.Select(x => new Team(x)).ToList();
        }
    }
}
