using System.Threading.Tasks;
using Core.Domain.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Login;
using Services.Register;
using Services.DropDown;
using System.Collections.Generic;

namespace KoolExplorer.Pages.Login
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public List<SelectListItem> PreSchoolList { get; set; }

        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IDropDownService _dropDownService;

        public RegisterModel(ILoginService loginService,
            IRegisterService registerService, IDropDownService dropDownService)
        {
            this._loginService = loginService;
            this._registerService = registerService;
            this._dropDownService = dropDownService;
        }

        [BindProperty]
        public RegisterViewModel registerModel { get; set; }

        //public void OnGetAsync()
        public async Task OnGetAsync()
        {
            registerModel = new RegisterViewModel();

            PreSchoolList = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "Please select a Pre-School" } };

          
            PreSchoolList.AddRange(await _dropDownService.GetDropDownByType("Register"));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                RegisterResultModel resultModel = await _registerService.RegisterUser(registerModel);

                if (resultModel.identityResult.Succeeded)
                {
                    await _loginService.SignInAsync(resultModel.identityUser);
                    return RedirectToPage("/Dashboard/Dashboard");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in resultModel.identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
