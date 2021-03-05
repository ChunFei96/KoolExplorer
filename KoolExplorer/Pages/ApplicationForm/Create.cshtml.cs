using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public FormModel(IParentService parentService)
        {
            _parentService = parentService;

        }
        public void OnGet()
        {
            formViewModel = new AdmissionModel();
            generalInformationViewModel = new GeneralInformationViewModel();
            parentsParticulars = new ParentsParticularsViewModel();
            childsParticulars = new ChildsParticularsViewModel();

            // dummy data
            generalInformationViewModel.Area = "West";
            generalInformationViewModel.District = "Clementi";
            generalInformationViewModel.PreSchool = "First School";
            generalInformationViewModel.Programme = "K1";
            generalInformationViewModel.ProgrammeTime = "Full-Day";
            //generalInformationViewModel.StartPeriod = "2021/10/08";

            parentsParticulars.Name1 = "Parent Name 1";
            parentsParticulars.PassportNo1 = "SJ910293";
            parentsParticulars.MobileNo1 = "90182932";
            parentsParticulars.Email1 = "parent1@gmail.com";

            parentsParticulars.Name2 = "Parent Name 2";
            parentsParticulars.PassportNo2 = "GN919283";
            parentsParticulars.MobileNo2 = "8891273";
            parentsParticulars.Email2 = "parent2@gmail.com";

            parentsParticulars.HomeTelNo = "69102932";
            parentsParticulars.StreetName = "Clementi Ave 6";

            parentsParticulars.BlockNo = "blk 120";
            parentsParticulars.FloorNo = "09";
            parentsParticulars.UnitNo = "51";

            parentsParticulars.BuildingName = "Clementi";

            parentsParticulars.PostalCode = "120202";
            parentsParticulars.HouseholdIncome = "$4001 - $4500";

            childsParticulars.Name = "Child Name";
            childsParticulars.BirthCertNo = "A910293";
            //childsParticulars.DOB = "1996/06/04";
            //childsParticulars.Gender = Core.Expansion.Enum.Gender.Male;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                formViewModel.GeneralInformationViewModel = generalInformationViewModel;
                formViewModel.ParentsParticularsViewModel = parentsParticulars;
                formViewModel.ChildsParticularsViewModel = childsParticulars;

                _parentService.SubmitApplicationForm(formViewModel);
            }
            return new RedirectToPageResult("../AcceptOffer/Index");
        }
    }
}
