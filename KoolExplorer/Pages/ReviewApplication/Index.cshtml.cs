using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.DropDown;
using Services.Operator;
using DAL;
using DAL.Entities;
using DAL.Entities.Operator;

namespace KoolExplorer.Pages.ReviewApplication
{
    public class ReviewAppModel : PageModel
    {
        private readonly IOperatorService _OperatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<ReviewViewModel> Applications;

        public ReviewAppModel(IOperatorService operatorService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _OperatorService = operatorService;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task OnGet()
        {
            var _userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Applications = await _OperatorService.RetrieveApplications(_userID);
            var maa = 0;
        }
    }
}
