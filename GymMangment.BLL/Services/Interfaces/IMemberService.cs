using GymMangment.BLL.ViewModels;
using GymMangment.BLL.ViewModels.MemberViewModels;
using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.BLL.Services.Interfaces
{
    public interface IMemberService
    {
        //Get All Member
        Task <IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct = default);
        Task<bool> CreateMemberAsync(CreateMemberViewModel member, CancellationToken ct = default);
    }
}
