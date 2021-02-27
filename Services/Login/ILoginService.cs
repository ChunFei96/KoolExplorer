using Core.Domain.Login;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Services.Login
{
    public interface ILoginService
    {
        Task<bool> PasswordSignInAsync(LoginViewModel loginViewModel);

        Task SignInAsync(IdentityUser user);

        Task SignOutAsync();
    }
}
