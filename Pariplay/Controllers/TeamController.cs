using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pariplay.API.EntityRequest;
using Pariplay.API.Workflows;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;

namespace Pariplay.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamWorkflow _teamWorkflow;

        public TeamController(ITeamWorkflow teamWorkflow)
        {
            _teamWorkflow = teamWorkflow;
        }

        [HttpGet]
        public IEnumerable<Team> GetAllTeam()
        {
            return _teamWorkflow.GetAllTeam();
        }

        [HttpGet("{teamId}")]
        public Team GetTeamById([FromRoute] int teamId)
        {
            return _teamWorkflow.GetTeamById(teamId);
        }

        [HttpGet("/WithMatches/{teamId}")]
        public TeamWithMatches GetTeamWithMatches([FromRoute] int teamId)
        {
            return _teamWorkflow.GetTeamWithMatchesByTeamId(teamId);
        }

        [HttpPost]
        public TeamDTO CreateTeam([FromBody] CreateTeam team)
        {
            return _teamWorkflow.CreateTeam(new TeamDTO{Name = team.Name});
        }

        [HttpPut("{id}")]
        public bool UpdateTeam([FromRoute]int id, [FromBody] CreateTeam team)
        {
            var updateTeam = new TeamDTO {Id = id, Name = team.Name};
            return _teamWorkflow.UpdateTeam(updateTeam);
        }
    }
}
