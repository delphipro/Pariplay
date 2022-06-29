using Pariplay.DataAccessLayer.DataObjects;

namespace Pariplay.Models
{
    public class Match
    {
        public Match(MatchDTO entity, bool host)
        {
            Visitor = entity.Visitor.Name;
            Host = entity.Host.Name;
            Result = $"{entity.TeamHostResult} - {entity.TeamVisitorResult}";
            Winner = host ? entity.TeamHostResult > entity.TeamVisitorResult : entity.TeamHostResult < entity.TeamVisitorResult;
        }

        public string Visitor { get; set; }

        public string Host { get; set; }

        public string Result { get; set; }

        public bool Winner { get; set; }
    }
}
