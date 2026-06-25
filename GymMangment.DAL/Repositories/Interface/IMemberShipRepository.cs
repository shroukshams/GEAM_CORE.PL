using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Repositories.Interface
{
   
    internal interface IMemberShipRepository : IGenericRepository<MemberShip>
    {
        IEnumerable<MemberShip> GetAllMemberSipsWithPlan(Func<MemberShip, bool>? filter = null
            );
    }
}
