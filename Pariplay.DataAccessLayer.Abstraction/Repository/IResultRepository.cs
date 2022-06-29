using System.Collections.Generic;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;
using Pariplay.Models.Enums;

namespace Pariplay.DataAccessLayer.Abstraction.Repository
{
    public interface IResultRepository
    {
        public void CreateResult(ActualResultDTO result);

        public void UpdateResult(ActualResultDTO result);

        public void UpdateResult(int teamId, EnumResult result, EnumResult? oldResult = null);

        public ActualResult GetResultById(int actualResultId);

        public ActualResult GetResultByTeamId(int teamId);

        public ICollection<ActualResult> GetAllResults();

    }
}
