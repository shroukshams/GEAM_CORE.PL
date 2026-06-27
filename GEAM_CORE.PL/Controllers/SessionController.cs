using GymMangment.BLL.Services.Interfaces;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using GymMangment.BLL.Services.Classes;
namespace GEAM_CORE.PL.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionServices _sessionServices;
           

        public SessionController(ISessionServices sessionServices)
        {
            _sessionServices = sessionServices;
        }

        public async Task<IActionResult> Index()
        {
            var sessions = await _sessionServices.GetSessionsAsync();
            return View();
        }
    }
}
