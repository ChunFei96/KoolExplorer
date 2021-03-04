using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Parent;

namespace KoolExplorer.Pages.AcceptOffer
{
    public class ViewAllModel : PageModel
    {
        private readonly IParentService _parentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public List<AdmissionModel> admissionViewModel { get; set; }
        public ViewAllModel(IParentService parentService, IHttpContextAccessor httpContextAccessor)
        {
            _parentService = parentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGet()
        {
            var userid = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) != null ?
                               _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : string.Empty;
            if(!string.IsNullOrEmpty(userid))
            {
                admissionViewModel = await _parentService.ViewAllApplication(userid);
            }
            else
                ModelState.AddModelError("Error", "Application records not found");
        }
    }
}
