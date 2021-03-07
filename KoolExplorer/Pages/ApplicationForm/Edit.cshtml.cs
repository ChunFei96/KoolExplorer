using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.DropDown;
using Services.Parent;

namespace KoolExplorer.Pages.ApplicationForm
{
    public class EditModel : PageModel
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
        private readonly IDropDownService _dropDownService;

        public EditModel(IParentService parentService, IDropDownService dropDownService)
        {
            _parentService = parentService;
            _dropDownService = dropDownService;
        }

        public async Task OnGetAsync(int id)
        {
            
        }

        public async Task OnPostEditAsync(int id)
        {
            formViewModel = await _parentService.EditApplicationForm(id.ToString());
            generalInformationViewModel = formViewModel.GeneralInformationViewModel;
            parentsParticulars = formViewModel.ParentsParticularsViewModel;
            childsParticulars = formViewModel.ChildsParticularsViewModel;

            //Init dropdownlist
            generalInformationViewModel.AreaList = await _dropDownService.GetDropDownByType("Area");
            generalInformationViewModel.DistrictList = await _dropDownService.GetDropDownByType("District");
            generalInformationViewModel.PreSchoolList = await _dropDownService.GetDropDownByType("PreSchool");
            generalInformationViewModel.ProgrammeList = await _dropDownService.GetDropDownByType("Programme");
        }

        public async Task<IActionResult> OnPostAsync()
        {

            formViewModel.GeneralInformationViewModel = generalInformationViewModel;
            formViewModel.ParentsParticularsViewModel = parentsParticulars;
            formViewModel.ChildsParticularsViewModel = childsParticulars;
            _parentService.EditApplicationForm(formViewModel);

            return new RedirectToPageResult("../AcceptOffer/Index");
        }
    }
}
