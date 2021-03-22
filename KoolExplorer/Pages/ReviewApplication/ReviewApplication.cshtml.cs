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
using Services.Parent;

namespace KoolExplorer.Pages.ReviewApplication
{
    public class ReviewApplicationModel : PageModel
    {
        [BindProperty]
        public AdmissionModel formViewModel { get; set; }
        [BindProperty]
        public GeneralInformationViewModel generalInformationViewModel { get; set; }
        [BindProperty]
        public ParentsParticularsViewModel parentsParticulars { get; set; }
        [BindProperty]
        public ChildsParticularsViewModel childsParticulars { get; set; }

        private readonly IParentService _parentService;
        private readonly IOperatorService _OperatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDropDownService _dropDownService;


        public ReviewApplicationModel(IParentService parentService,IOperatorService operatorService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IDropDownService dropDownService)
        {
            _parentService = parentService;
            _OperatorService = operatorService;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dropDownService = dropDownService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostReviewAsync(int id)
        {
            formViewModel = await _parentService.EditApplicationForm(id.ToString());
            generalInformationViewModel = formViewModel.GeneralInformationViewModel;
            parentsParticulars = formViewModel.ParentsParticularsViewModel;
            childsParticulars = formViewModel.ChildsParticularsViewModel;

            //Init dropdownlist
            generalInformationViewModel.AreaList = new List<SelectListItem>() { new SelectListItem() { Value = "-", Text = "Please select an Area" } };
            generalInformationViewModel.AreaList.AddRange(await _dropDownService.GetDropDownByType("Area"));
            generalInformationViewModel.DistrictList = await _dropDownService.GetDropDownByType("District");
            generalInformationViewModel.PreSchoolList = await _dropDownService.GetDropDownByType("PreSchool");
            generalInformationViewModel.ProgrammeList = await _dropDownService.GetDropDownByType("Programme");

            var maa = 0;
        }

        public async void OnPostAsync(string button) //Task<IActionResult>
        {

            

            //return new RedirectToPageResult("../AcceptOffer/Index");
            var maa = 0;
        }
    }
}
