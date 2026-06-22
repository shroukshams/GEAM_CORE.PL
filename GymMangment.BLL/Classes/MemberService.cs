using GymMangment.BLL.Services.Interfaces;
using GymMangment.BLL.ViewModels;
using GymMangment.BLL.ViewModels.MemberViewModels;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymMangment.BLL.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepo;
        public MemberService(IGenericRepository<Member> memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<bool> CreateMemberAsync(CreateMemberViewModel member, CancellationToken ct = default)
        {
            // email exist or not
            // phone exist or not
            var EmailExist = await _memberRepo.AnyAsync(X => X.Email == member.Email);
            var PhoneExist = await _memberRepo.AnyAsync(X => X.Email == member.Phone);

            if (EmailExist || PhoneExist) return false;
            var _member = new Member()
            { 
            Name=member.Name,
            Email=member.Email,
            phonenumber=member.Phone,
            dateofBirth=member.DateOfBirth,
            Address=new Adress()
            {

                number=member.BuildingNumber,
                City=member.City,
                Street=member.Street,
            },
            HealthRecord=new HealthRecord()
            {
                bloodType=member.HealthRecordViewModel.BloodType,
                heigh=member.HealthRecordViewModel.Height,
                weight=member.HealthRecordViewModel.Weight,
                Note=member.HealthRecordViewModel.Note,
            }
            };
            var result=await _memberRepo.AddAsync(_member);
            return result > 0;
        }
    


        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct = default)
        {
            var members = await _memberRepo.GetAllAsync(ct: ct);


            if (!members.Any()) return [];
            List<MemberViewModel> memberVM = new List<MemberViewModel>();
            foreach (var member in members) 
            {
                var memberViewmodel = new MemberViewModel()
                {
                    Name = member.Name,
                    Phone = member.phonenumber,
                    Photo = member.photo,
                    Email = member.Email,
                    Id = member.ID,
                    Gender = member.Gender.ToString()
                };
                memberVM.Add(memberViewmodel);
                }
            return memberVM;


        }
 
      
    }
    } 

