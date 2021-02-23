using Microsoft.AspNetCore.Mvc;
using Services.GovAPI;
using System.Threading.Tasks;

namespace KoolExplorer.Controllers
{
    public class GovAPIController : Controller
    {
        public GovAPIController(IGovAPIService govAPIService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
