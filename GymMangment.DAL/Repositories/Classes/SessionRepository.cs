using GymManagement.DAL.Repositories.Interfaces;
using GymMangment.DAL.Context;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;

namespace GymMangment.DAL.Repositories.Classes
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDbContext _dbContext;
        public SessionRepository(GymDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountOfBookedSlotsAsync(int sessionId, CancellationToken ct = default)
        {
            return await _dbContext.Bookings.AsNoTracking().CountAsync(B => B.SessionId == sessionId);
        }

        public async Task<IEnumerable<Session>> GetAllSessionsWithTrainerAndCategoryAsync(Expression<Func<Session, bool>>? predicate = null, CancellationToken ct = default)
        {
            IQueryable<Session> query = _dbContext.Sessions
                                                  .AsNoTracking()
                                                  .Include(S => S.Trainer)
                                                  .Include(S => S.Category);
            if (predicate is not null) query = query.Where(predicate);
            return await query.ToListAsync();
        }


        public async Task<IEnumerable<Session>> GetSessionsWithTrainerAndCategory(CancellationToken ct = default)
        {
            var query = _dbContext.Sessions.AsNoTracking().Include(x => x.Trainer).Include(x => x.Category);
            return await query.ToListAsync();
        }
        public async Task<Session> GetSessionByIdWithTrainerAndCategory(int sessionId, CancellationToken ct = default)
        {
            return await _dbContext.Sessions
                                    .AsNoTracking()
                                    .Include(S => S.Trainer)
                                    .Include(S => S.Category)
                                    .FirstOrDefaultAsync(S => S.ID == sessionId);
        }
    }
}
