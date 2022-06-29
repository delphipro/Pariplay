using System;
using System.Collections.Generic;
using Pariplay.DataAccessLayer.Abstraction;
using Pariplay.Models;

namespace Pariplay.API.Workflows
{
    public interface IResultWorkflow
    {
        ICollection<ActualResult> GetAllResults();
    }

    public class ResultWorkflow: IResultWorkflow
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResultWorkflow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<ActualResult> GetAllResults()
        {
                var result = _unitOfWork.Result.GetAllResults();

                return result;
        }
    }
}
