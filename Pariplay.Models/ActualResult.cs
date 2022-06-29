using System;
using Pariplay.DataAccessLayer.DataObjects;

namespace Pariplay.Models
{
    public class ActualResult
    {
        public ActualResult(ActualResultDTO entity)
        {
            TeamName = entity.Team.Name;
            Wins = entity.Wins;
            Equality = entity.Equality;
            Losses = entity.Losses;
        }

        public string TeamName { get; set; }

        public int Wins { get; set; }

        public int Equality { get; set; }

        public int Losses { get; set; }

        public int TotalResult => Wins*3 + Equality;
    }
}
