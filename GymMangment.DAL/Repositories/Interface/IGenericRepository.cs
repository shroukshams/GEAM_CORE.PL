using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GymMangment.DAL.Repositories.Interface
{
    public interface IGenericRepository<IEntity> where IEntity : BaseEntity,new()
    {        //Get All IEntity
        Task<IEnumerable<IEntity>> GetAllAsync(bool tracking = false, CancellationToken ct = default);
        //Get IEntity By Id
        Task<IEntity> GetByIdAsync(int id, CancellationToken ct = default);
        //Add IEntity
        Task<int> AddAsync(IEntity entity, CancellationToken ct = default);
        //Update IEntity
        Task<int> UpdateAsync(IEntity entity, CancellationToken ct = default);
        //  Delete IEntity
        Task<int> DeleteAsync(IEntity entity, CancellationToken ct = default);
        Task <bool>AnyAsync(Expression<Func<IEntity,bool>>predicate,CancellationToken ct = default);
       //void AnyAsync(Session session);
    }
}

