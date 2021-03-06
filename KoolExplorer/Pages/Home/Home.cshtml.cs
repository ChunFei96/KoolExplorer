using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Parent;

namespace KoolExplorer.Pages.Home
{
    public class HomeModel : PageModel
    {
        private readonly IParentService _parentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int TotalSchools;
        public int TotalSubmissions;
        public int TotalAcceptances;

        public HomeModel(IParentService parentService, IHttpContextAccessor httpContextAccessor)
        {
            _parentService = parentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            TotalSchools =  _parentService.getTotalSchools().Result;
            TotalSubmissions =  _parentService.getTotalSubmissions(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            TotalAcceptances =  _parentService.getTotalAcceptances(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
        }
    }
}
