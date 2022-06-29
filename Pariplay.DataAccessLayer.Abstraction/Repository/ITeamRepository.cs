using System.Collections.Generic;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;

namespace Pariplay.DataAccessLayer.Abstraction.Repository
{
    public interface ITeamRepository
    {
        public void CreateTeam(TeamDTO team);

        public void UpdateTeam(TeamDTO team);

        public Team GetTeamById(int teamId);

        public TeamWithMatches GetTeamWithMatchesByTeamId(int teamId);

        public ICollection<Team> GetAllTeams();
    }
}