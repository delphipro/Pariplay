using System.Collections.Generic;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;

namespace Pariplay.DataAccessLayer.Abstraction.Repository
{
    public interface IMatchRepository
    {
        public void CreateMatch(MatchDTO match);

        public void UpdateMatch(MatchDTO match);

        public Match GetMatchById(int matchId);

        public ICollection<Match> GetAllMatchesByTeam(int teamId);
    }
}
