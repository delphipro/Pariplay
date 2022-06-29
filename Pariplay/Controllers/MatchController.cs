using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pariplay.API.EntityRequest;
using Pariplay.API.Workflows;
using Pariplay.DataAccessLayer.DataObjects;
using Pariplay.Models;

namespace Pariplay.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchWorkflow _matchWorkflow;

        public MatchController(IMatchWorkflow matchWorkflow)
        {
            _matchWorkflow = matchWorkflow;
        }

        [HttpGet("{id}")]
        public Match GetMatchById([FromRoute] int id)
        {
            return _matchWorkflow.GetMatchById(id);
        }

        [HttpPost]
        public MatchDTO CreateMatch(CreateMatch match)
        {
            var newMatch = new MatchDTO
            {
                VisitorId = match.VisitorId,
                HostId = match.HostId,
                TeamVisitorResult = match.VisitorResult,
                TeamHostResult = match.HostResult
            };
            return _matchWorkflow.CreateMatch(newMatch);
        }
    }
}
