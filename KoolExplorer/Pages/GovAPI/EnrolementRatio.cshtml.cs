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
    public class EnrolementRatioModel : PageModel
    {
        private readonly IGovAPIService _govAPIService;
        private readonly IMapper _mapper;
        public List<EnrolementRatio> EnrolementList { get; set; }

        public EnrolementRatioModel(IGovAPIService govAPIService, IMapper mapper)
        {
            _govAPIService = govAPIService;
            _mapper = mapper;
        }


        public async Task OnGetAsync()
        {
            EnrolementList = await _govAPIService.GetNetEnrolmentRatio();
        }
    }
}
