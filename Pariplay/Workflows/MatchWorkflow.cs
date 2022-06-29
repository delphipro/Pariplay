using System;
using Pariplay.DataAccessLayer.Abstraction;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;
using Pariplay.Models.Enums;

namespace Pariplay.API.Workflows
{
    public interface IMatchWorkflow
    {
        MatchDTO CreateMatch(MatchDTO match);

        Match GetMatchById(int id);
    }

    public class MatchWorkflow: IMatchWorkflow
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchWorkflow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MatchDTO CreateMatch(MatchDTO match)
        {
            try
            {
                if (match.VisitorId == match.HostId)
                {
                    throw new Exception("Тhe team cannot play against itself!", null);
                }

                var resultHost = match.TeamHostResult > match.TeamVisitorResult ? EnumResult.Win :
                    match.TeamHostResult == match.TeamVisitorResult ? EnumResult.Equality : EnumResult.Loss;
                var resultVisitor = match.TeamHostResult < match.TeamVisitorResult ? EnumResult.Win :
                    match.TeamHostResult == match.TeamVisitorResult ? EnumResult.Equality : EnumResult.Loss;

                _unitOfWork.Match.CreateMatch(match);
                _unitOfWork.Result.UpdateResult(match.HostId, resultHost);
                _unitOfWork.Result.UpdateResult(match.VisitorId, resultVisitor);
                if (_unitOfWork.SaveChanges())
                {
                    return match;
                }

                return null;
            }
            catch (Exception ex)
            {
                //save exception in logs
               throw new Exception("The system could not save the match! Please check logs!", ex);
            }
            finally
            {
                //save logs with results
            }
        }

        public Match GetMatchById(int id)
        {
            try
            {
                return _unitOfWork.Match.GetMatchById(id);
            }
            catch (Exception ex)
            {
                //save exception in logs
                throw new Exception("The system could not save the team! Please check logs!", ex);
            }
            finally
            {
                //save logs with results
            }
        }
    }
}
