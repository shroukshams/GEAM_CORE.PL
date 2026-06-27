using GymMangment.DAL.Context;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _dbContext;
        private readonly Dictionary<string, object> _repositories = [];
        public UnitOfWork(GymDbContext dbContext, ISessionRepository sessionRepository)
        {
            this._dbContext = dbContext;
            SessionRepository = sessionRepository;
        }
        public ISessionRepository SessionRepository { get; }
    
        public IGenericRepository<IEntity> GetRepository<IEntity>() where IEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
