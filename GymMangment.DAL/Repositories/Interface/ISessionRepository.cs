using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using System.Linq.Expressions;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface ISessionRepository : IGenericRepository<Session>
    {
        Task<IEnumerable<Session>> GetSessionsWithTrainerAndCategory(CancellationToken ct = default);

        Task<int> CountOfBookedSlotsAsync(int sessionId, CancellationToken ct = default);

        Task<IEnumerable<Session>> GetAllSessionsWithTrainerAndCategoryAsync(
            Expression<Func<Session, bool>>? predicate = null,
            CancellationToken ct = default);

        Task<Session> GetSessionByIdWithTrainerAndCategory(int sessionId, CancellationToken ct = default);

    }
}