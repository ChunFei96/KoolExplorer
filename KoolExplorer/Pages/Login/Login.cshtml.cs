using Core.Domain.Login;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Login;

namespace KoolExplorer.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILoginService _loginService;
        public LoginModel(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        [BindProperty]
        public LoginViewModel loginModel { get; set; }
        public void OnGetAsync()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (await _loginService.PasswordSignInAsync(loginModel))
                {
                    return RedirectToPage("/Dashboard/Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _loginService.SignOutAsync();
            return RedirectToPage("Login");
        }
    }
}
