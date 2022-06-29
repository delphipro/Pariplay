using System;
using System.Collections.Generic;
using Pariplay.DataAccessLayer.Abstraction;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;

namespace Pariplay.API.Workflows
{
    public interface ITeamWorkflow
    {
        ICollection<Team> GetAllTeam();

        TeamDTO CreateTeam(TeamDTO team);

        Team GetTeamById(int teamId);

        TeamWithMatches GetTeamWithMatchesByTeamId(int teamId);

        bool UpdateTeam(TeamDTO team);
    }

    public class TeamWorkflow: ITeamWorkflow
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamWorkflow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<Team> GetAllTeam()
        {
            return _unitOfWork.Team.GetAllTeams();
        }

        public TeamDTO CreateTeam(TeamDTO team)
        {
            try
            {
                _unitOfWork.Team.CreateTeam(team);
                _unitOfWork.Result.CreateResult(new ActualResultDTO{Team = team});
                if (_unitOfWork.SaveChanges())
                {
                    return team;
                }

                return null;
            }
            catch
            {
                //save exception in logs
                throw new Exception("The system could not save the team! Please check logs!");
            }
            finally
            {
                //save logs with results
            }
        }

        public Team GetTeamById(int teamId)
        {
            try
            {
                return _unitOfWork.Team.GetTeamById(teamId);
            }
            catch
            {
                //save exception in logs
                throw new Exception($"The system could not return a team with Id: {teamId}! Please check logs!");
            }
        }

        public TeamWithMatches GetTeamWithMatchesByTeamId(int teamId)
        {
            try
            {
                return _unitOfWork.Team.GetTeamWithMatchesByTeamId(teamId);
            }
            catch
            {
                //save exception in logs
                throw new Exception($"The system could not return a team with Id: {teamId}! Please check logs!");
            }
        }

        public bool UpdateTeam(TeamDTO team)
        {
            try
            {
                _unitOfWork.Team.UpdateTeam(team);
                return _unitOfWork.SaveChanges();
            }
            catch
            {
                throw new Exception("The system could not update the team! Please check logs!");
            }
            finally
            {
                //save logs
            }
        }
    }
}
