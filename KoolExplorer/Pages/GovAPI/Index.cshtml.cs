using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.GovAPI;
using Core.Domain.GovAPI;
using AutoMapper;
using DAL.Entities;

namespace KoolExplorer.Pages.GovAPI
{
    public class IndexModel : PageModel
    {
        private readonly IGovAPIService _govAPIService;
        private readonly IMapper _mapper;
        public List<CentreServices> centreServicesList { get; set; }

        public IndexModel(IGovAPIService govAPIService, IMapper mapper)
        {
            _govAPIService = govAPIService;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            centreServicesList = await _govAPIService.GetListOfCentreServices();
        }


    }
}
