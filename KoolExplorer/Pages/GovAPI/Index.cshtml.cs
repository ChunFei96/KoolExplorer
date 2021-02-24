using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoolExplorer.Model.GovAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.GovAPI;
using KoolExplorer.Model.GovAPI;
using AutoMapper;

namespace KoolExplorer.Pages.GovAPI
{
    public class IndexModel : PageModel
    {
        private readonly IGovAPIService _govAPIService;
        private readonly IMapper _mapper;
        public List<GetListingOfCentreServicesResponse> centreServicesList { get; set; }

        public IndexModel(IGovAPIService govAPIService, IMapper mapper)
        {
            _govAPIService = govAPIService;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            centreServicesList =  _mapper.Map<List<GetListingOfCentreServicesResponse>>(await _govAPIService.GetListOfCentreServices());
        }


    }
}
