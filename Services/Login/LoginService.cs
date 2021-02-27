using Core.Domain.Login;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Services.Login
{
    public partial class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginService(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public virtual async Task<bool> PasswordSignInAsync(LoginViewModel loginViewModel)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(
                       loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);

            return result.Succeeded;
        }

        public virtual async Task SignInAsync(IdentityUser user)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
        }
        public virtual async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
