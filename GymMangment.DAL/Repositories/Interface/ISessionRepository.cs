using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Repositories.Interface
{
   public interface ISessionRepository : IGenericRepository <Session>
    {
        Task<IEnumerable<Session>> GetSessionsWithTrainerAndCategory (CancellationToken ct =default);
        Task<int> CountOfBookedSlotsAsync(int sessionId,CancellationToken ct =default);
    }
}
