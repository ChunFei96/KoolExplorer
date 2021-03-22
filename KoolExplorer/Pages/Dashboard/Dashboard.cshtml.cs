using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Dashboard;
using Services.Parent;
using Services.Operator;

namespace KoolExplorer.Pages.Dashboard
{
    public class DashboardModel : PageModel
    {
        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }

        private readonly IDashboardService _dashboardService;

        [BindProperty]
        public Dictionary<string,int> sparkCertifiedRatio { get; set; }
        [BindProperty]
        public string organisationRatio { get; set; }
        [BindProperty]
        public string serviceOfferedRatio { get; set; }

        [BindProperty]
        public string TotalApplications { get; set; } 
        [BindProperty]
        public string TotalAccepted { get; set; }
        [BindProperty]
        public string TotalPending { get; set; }

        private readonly IParentService _parentService;
        private readonly IOperatorService _OperatorService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int TotalSchools;
        public int TotalSubmissions;
        public int TotalAcceptances;

        public DashboardModel(IDashboardService dashboardService, IOperatorService operatorService, IParentService parentService, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardService = dashboardService;
            _parentService = parentService;
            _httpContextAccessor = httpContextAccessor;
            _OperatorService = operatorService;
        }

        public void OnGet()
        {
            // Ref: https://www.chartjs.org/docs/latest/
            sparkCertifiedRatio = _dashboardService.GetSparkCertifiedRatio();
            organisationRatio = _dashboardService.GetOrganisationRatio();
            serviceOfferedRatio = _dashboardService.GetServiceOfferedRatio();

            TotalSchools = _parentService.getTotalSchools().Result;
            TotalSubmissions = _parentService.getTotalSubmissions(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            TotalAcceptances = _parentService.getTotalAcceptances(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;

            var kkk = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var aa = _OperatorService.TotalApplications(kkk);
            TotalApplications = aa.ToString(); 
            TotalAccepted = "1";
            TotalPending = "1";


            //age, gender,race,citizen
        }
    }
}
