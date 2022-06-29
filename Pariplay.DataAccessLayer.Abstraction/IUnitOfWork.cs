using System;
using Pariplay.DataAccessLayer.Abstraction.Repository;

namespace Pariplay.DataAccessLayer.Abstraction
{
    public interface IUnitOfWork: IDisposable
    {
        IMatchRepository Match { get; }

        IResultRepository Result { get; }

        ITeamRepository Team { get; }

        public bool SaveChanges();
    }
}
