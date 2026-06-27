using AutoMapper;
using GymMangment.BLL.ViewModels.MemberViewModels;
using GymMangment.DAL.Models;
using Microsoft.IdentityModel.Tokens;

namespace GymMangment.BLL.Profiles
{
    public class MappingProfile : Profile   // <-- لازم يرث من Profile
    {
        public MappingProfile()             // <-- Constructor
        {
            CreateMap<Member, MemberViewModel>();
         
            
            
            
            //  .ForMember(dest => dest.Adress, opt => opt.MapFrom(src=>$"{Src."));



            private void SessionProfiles()
        {
            CreateMap<CreateMemberViewModel, Session>();



        }
               
        }
    }
