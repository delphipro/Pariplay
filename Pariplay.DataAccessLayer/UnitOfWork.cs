using System;
using Pariplay.DataAccessLayer.Abstraction;
using Pariplay.DataAccessLayer.Abstraction.Repository;
using Pariplay.DataAccessLayer.DbContextConfig;
using Pariplay.DataAccessLayer.Repository;

namespace Pariplay.DataAccessLayer
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly PariplayDbContext _dbContext;

        private bool _disposed;

        private readonly Lazy<IMatchRepository> _match;

        private readonly Lazy<ITeamRepository> _team;

        private readonly Lazy<IResultRepository> _result;

        public UnitOfWork(PariplayDbContext dbContext)
        {
            _dbContext = dbContext;

            _match = new Lazy<IMatchRepository>(() => new MatchRepository(_dbContext));
            _team = new Lazy<ITeamRepository>(() => new TeamRepository(_dbContext));
            _result = new Lazy<IResultRepository>(() => new ResultRepository(_dbContext));
        }

        public IMatchRepository Match => _match.Value;
        public IResultRepository Result => _result.Value;
        public ITeamRepository Team => _team.Value;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
           return _dbContext.SaveChanges() != 0;
        }
    }
}
