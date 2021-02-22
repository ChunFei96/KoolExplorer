using Microsoft.AspNetCore.Mvc;
using Services.GovAPI;
using System.Threading.Tasks;

namespace KoolExplorer.Controllers
{
    public class GovAPIController : Controller
    {
        private readonly IGovAPIService _govAPIService;

        public GovAPIController(IGovAPIService govAPIService)
        {
            _govAPIService = govAPIService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _govAPIService.GetListOfCentreServices();
            return View();
        }
    }
}
