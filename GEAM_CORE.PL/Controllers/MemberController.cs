using GymMangment.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GEAM_CORE.PL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

    
        #region Get Member
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var members=await _memberService.GetAllMembersAsync(ct);
            return View(members);
        }


        #endregion

        #region Create Member
        public IActionResult Create()
            => View();

        #endregion

        #region Edit Member
        #endregion

        #region Delete Member
        #endregion
   
    }
}
