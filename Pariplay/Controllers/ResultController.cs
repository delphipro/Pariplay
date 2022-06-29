using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pariplay.API.Workflows;
using Pariplay.Models;

namespace Pariplay.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly IResultWorkflow _resultWorkflow;

        public ResultController(IResultWorkflow resultWorkflow)
        {
            _resultWorkflow = resultWorkflow;
        }

        [HttpGet]
        public ICollection<ActualResult> GetAllResults()
        {
            return _resultWorkflow.GetAllResults();
        }
    }
}
