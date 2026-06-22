using GymMangment.DAL.Context;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GymMangment.DAL.Repositories.Classes
{
    public class GenericRepository<IEntity> : IGenericRepository<IEntity> where IEntity : BaseEntity, new()
    {
        private readonly GymDbContext dbContext;
        private readonly DbSet<IEntity> dbSet;
        public GenericRepository(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<IEntity>();
        }
        public async Task<int> AddAsync(IEntity entity, CancellationToken ct = default)
        {
            dbSet.Add(entity);
            return await dbContext.SaveChangesAsync(ct);
        }

        public Task<bool> AnyAsync(Expression<Func<IEntity, bool>> predicate, CancellationToken ct = default)
        {
            return dbSet.AsNoTracking().AnyAsync(predicate, ct);
        }

        public Task<int> DeleteAsync(IEntity entity, CancellationToken ct = default)
        {
            dbSet.Remove(entity);
            return dbContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<IEntity>> GetAllAsync(bool tracking = false, CancellationToken ct = default)
        {
            //IQueryable<IEntity> query = tracking ? dbContext.Set<IEntity>() : dbContext.Set<IEntity>().AsNoTracking();
            //   return await  query.ToListAsync(ct);
            if (tracking)
            {
                return await dbContext.Set<IEntity>().ToListAsync(ct);
            }
            else
            {
                return await dbContext.Set<IEntity>().AsNoTracking().ToListAsync(ct);
            }

        }

        public async Task<IEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await dbContext.Set<IEntity>().FindAsync(id, ct);
        }

        public async Task<int> UpdateAsync(IEntity entity, CancellationToken ct = default)
        {
            dbContext.Set<IEntity>().Update(entity);
            return await dbContext.SaveChangesAsync(ct);
        }
    }
}

