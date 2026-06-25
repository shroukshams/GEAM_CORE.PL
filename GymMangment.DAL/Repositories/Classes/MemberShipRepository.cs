using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
namespace GymMangment.DAL.Repositories.Classes
{
    internal class MemberShipRepository : IMemberShipRepository
    {
        public Task<int> AddAsync(MemberShip entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> predicate, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(MemberShip entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MemberShip>> GetAllAsync(bool tracking = false, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberShip> GetAllMemberSipsWithPlan(Func<MemberShip, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<MemberShip> GetByIdAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MemberShip entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
