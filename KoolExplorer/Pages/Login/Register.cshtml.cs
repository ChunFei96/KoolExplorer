using System.Threading.Tasks;
using Core.Domain.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Login;
using Services.Register;

namespace KoolExplorer.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        public RegisterModel(ILoginService loginService,
            IRegisterService registerService)
        {
            this._loginService = loginService;
            this._registerService = registerService;
        }

        [BindProperty]
        public RegisterViewModel registerModel { get; set; }

        public void OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                RegisterResultModel resultModel = await _registerService.RegisterUser(registerModel);
                if (resultModel.identityResult.Succeeded)
                {
                    await _loginService.SignInAsync(resultModel.identityUser);
                    return RedirectToPage("/Home/Home");
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
