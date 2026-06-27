using GymMangment.DAL.Context;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GymMangment.DAL.Repositories.Classes
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDbContext dbContext;
        public SessionRepository(GymDbContext dbContext) : base(dbContext)
        {
            {
            this.dbContext = dbContext;
        }
        }

        public async Task<int> CountOfBookedSlotsAsync(int sessionId, CancellationToken ct = default)
        {
            return await dbContext.Bookings.AsNoTracking().CountAsync(B=>B.SessionId==sessionId);
        }

        public async Task<IEnumerable<Session>> GetSessionsWithTrainerAndCategory(CancellationToken ct = default)
        {
            var Query = dbContext.Sessions.AsNoTracking().Include(S => S.Trainer).Include(S => S.Category);
            return await Query.ToListAsync();
        }
    }
}
