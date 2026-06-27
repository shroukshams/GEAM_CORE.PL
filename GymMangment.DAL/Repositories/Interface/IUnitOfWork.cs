using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Repositories.Interface
{
    public interface IUnitOfWork

    {
        IGenericRepository<IEntity> GetRepository<IEntity>() where IEntity : BaseEntity, new();
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        public ISessionRepository SessionRepository { get; }
    }
}
