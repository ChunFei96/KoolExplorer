using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.GovAPI;
using Core.Domain.GovAPI;
using DAL.Entities;
using AutoMapper;

namespace KoolExplorer.Pages.GovAPI
{
    public class CentresModel : PageModel
    {
        private readonly IGovAPIService _govAPIService;
        private readonly IMapper _mapper;
        public List<Centres> CentresList { get; set; }

        public CentresModel(IGovAPIService govAPIService, IMapper mapper)
        {
            _govAPIService = govAPIService;
            _mapper = mapper;
        }


        public async Task OnGetAsync()
        {
            CentresList = await _govAPIService.GetListingOfCentres();
        }
    }
}
