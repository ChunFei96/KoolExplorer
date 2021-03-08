using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Filter;
using Core.Domain.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Services.DropDown;
using Services.Filter;
using Services.Parent;

namespace KoolExplorer.Pages.ApplicationForm
{
    public class FormModel : PageModel
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

        public FormModel(IParentService parentService, IDropDownService dropDownService)
        {
            _parentService = parentService;
            _dropDownService = dropDownService;
        }

        public async void OnGet()
        {
            formViewModel = new AdmissionModel();
            generalInformationViewModel = new GeneralInformationViewModel();
            parentsParticulars = new ParentsParticularsViewModel();
            childsParticulars = new ChildsParticularsViewModel();

            //Init dropdownlist
            generalInformationViewModel.AreaList = new List<SelectListItem>() { new SelectListItem() { Value = "-", Text = "Please select an Area" } };
            generalInformationViewModel.AreaList.AddRange(await  _dropDownService.GetDropDownByType("Area"));
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                formViewModel.GeneralInformationViewModel = generalInformationViewModel;
                formViewModel.ParentsParticularsViewModel = parentsParticulars;
                formViewModel.ChildsParticularsViewModel = childsParticulars;

                _parentService.SubmitApplicationForm(formViewModel);
                return new RedirectToPageResult("../AcceptOffer/Index");
            }
            return Page();

        }

       
    }
}
