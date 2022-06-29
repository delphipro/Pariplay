using System.Collections.Generic;
using System.Linq;
using Pariplay.DataAccessLayer.Abstraction.Repository;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.DataAccessLayer.DbContextConfig;
using Pariplay.Models;
using Pariplay.Models.Enums;

namespace Pariplay.DataAccessLayer.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly PariplayDbContext _dbcontext;

        public ResultRepository(PariplayDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void CreateResult(ActualResultDTO actualResult)
        {
            _dbcontext.Add(actualResult);
        }

        public void UpdateResult(ActualResultDTO actualResult)
        {
            var record = _dbcontext.ActualResult.FirstOrDefault(x => x.Id == actualResult.Id);
            if (record == null) return;
            record.Wins = actualResult.Wins;
            record.Equality = actualResult.Equality;
            record.Losses = actualResult.Losses;
            record.Team = actualResult.Team;
            record.TeamId = actualResult.TeamId;
        }

        public void UpdateResult(int teamId, EnumResult result, EnumResult? oldResult = null)
        {
            if(result == oldResult) return;
            var record = _dbcontext.ActualResult.FirstOrDefault(x => x.TeamId == teamId);
            if (record == null) return;
            if (oldResult != null)
            {
                switch (oldResult)
                {
                    case EnumResult.Loss:
                        record.Losses -= 1;
                        break;
                    case EnumResult.Equality:
                        record.Equality -= 1;
                        break;
                    case EnumResult.Win:
                        record.Wins -= 1;
                        break;
                }
            }

            switch (result)
            {
                case EnumResult.Loss:
                    record.Losses += 1;
                    break;
                case EnumResult.Equality:
                    record.Equality += 1;
                    break;
                case EnumResult.Win:
                    record.Wins += 1;
                    break;
            }
        }

        public ActualResult GetResultById(int actualResultId)
        {
            var record = _dbcontext.ActualResult.FirstOrDefault(x => x.Id == actualResultId);
            if (record == null) return null;
            return new ActualResult(record);
        }

        public ActualResult GetResultByTeamId(int teamId)
        {
            var record = _dbcontext.ActualResult.FirstOrDefault(x => x.TeamId == teamId);
            if (record == null) return null;
            return new ActualResult(record);
        }

        public ICollection<ActualResult> GetAllResults()
        {
            var records = _dbcontext.ActualResult.ToList();
            return records.Select(x => new ActualResult(x)).ToList();
        }
    }
}
