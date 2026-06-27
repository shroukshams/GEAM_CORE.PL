using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //get repo

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new();

        // save changes
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        // sessions
        public ISessionRepository SessionRepository { get; }
    }
}