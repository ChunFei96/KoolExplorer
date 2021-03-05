using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Parent;

namespace KoolExplorer.Pages.Home
{
    public class HomeModel : PageModel
    {
        private readonly IParentService _parentService;

        public int TotalSchools;
        public int TotalSubmissions;
        public int TotalAcceptances;

        public HomeModel(IParentService parentService)
        {
            _parentService = parentService;

        }

        public void OnGet()
        {
            TotalSchools =  _parentService.getTotalSchools().Result;
            TotalSubmissions =  _parentService.getTotalSchools().Result;
            TotalAcceptances =  _parentService.getTotalSchools().Result;
        }
    }
}
