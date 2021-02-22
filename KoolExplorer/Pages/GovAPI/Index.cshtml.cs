using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.GovAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.GovAPI;

namespace KoolExplorer.Pages.GovAPI
{
    public class IndexModel : PageModel
    {
        private readonly IGovAPIService _govAPIService;
        public List<GetListingOfCentreServicesResponse> centreServicesList { get; set; }

        public IndexModel(IGovAPIService govAPIService)
        {
            _govAPIService = govAPIService;
        }

        public async Task OnGetAsync()
        {
            centreServicesList = await _govAPIService.GetListOfCentreServices();
        }


    }
}
