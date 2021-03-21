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
            generalInformationViewModel.AreaList = new List<SelectListItem>() { new SelectListItem() { Value = "-", Text = "Please select an Area" } };
            generalInformationViewModel.AreaList.AddRange(await _dropDownService.GetDropDownByType("Area"));
            generalInformationViewModel.DistrictList = await _dropDownService.GetDropDownByType("District");
            generalInformationViewModel.PreSchoolList = await _dropDownService.GetDropDownByType("PreSchool");
            generalInformationViewModel.ProgrammeList = await _dropDownService.GetDropDownByType("Programme");

            childsParticulars.CitizenshipList = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "Please select a Citizenship" } };
            childsParticulars.CitizenshipList.AddRange(await _dropDownService.GetDropDownByType("Citizenship"));

            childsParticulars.RaceList = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "Please select a Race" } };
            childsParticulars.RaceList.AddRange(await _dropDownService.GetDropDownByType("Race"));
        }

        public async Task<IActionResult> OnPostAcceptOfferAsync(int id)
        {
            _parentService.AcceptApplicationForm(id.ToString());

            return new RedirectToPageResult("../AcceptOffer/Index");
        }

        public async Task<IActionResult> OnPostRejectOfferAsync(int id)
        {
            _parentService.RejectApplicationForm(id.ToString());

            return new RedirectToPageResult("../AcceptOffer/Index");
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
