using GymMangement.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

    namespace GEAM_CORE.PL.Controllers
{
    public class PlanController : Controller
    {
        // private readonly GymDbContexts context;
        private readonly IPlanRepository planRepository;
        public PlanController(IPlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }



        //Get:BaseUrl/Plan/Index

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await planRepository.GetAllAsync(ct: ct);//pass by name
            return View(plans);
        }

        public async Task<IActionResult> Details(int id, CancellationToken ct)
            {
                 var plan = await planRepository.GetByIdAsync(id, ct);
         
                if (plan == null)
                     {
                  return RedirectToAction(nameof(Index));
    }
    else
          {  return View(plan);
}


        
   
        
    }
  


    }
    }

