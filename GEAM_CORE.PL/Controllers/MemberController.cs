using GymMangment.BLL.Services.Interfaces;
using GymMangment.BLL.ViewModels.MemberViewModels;
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
        [HttpPost]
        public async Task<IActionResult>CreateMember(CreateMemberViewModel model, CancellationToken ct)
        {

            if (!ModelState.IsValid)return View(nameof(Create),model);
            var result=await _memberService.CreateMemberAsync(model, ct);

            if (result)
                TempData["SuccessMessage"] = "MemberCreated Succesfuly";
            else
                TempData["ErrorMessage"] = "MemberCreated is failed";

            return Redirect(nameof(Index));
        }
    }
            
          
        #endregion

        #region Edit Member
        #endregion

        #region Delete Member
        #endregion
   
    }

