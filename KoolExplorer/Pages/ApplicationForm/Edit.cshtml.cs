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
        

        public EditModel(IParentService parentService)
        {
            _parentService = parentService;
           
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
