using Core.Domain.Login;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Register
{
    public partial class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public virtual async Task<RegisterResultModel> RegisterUser(RegisterViewModel registerViewModel)
        {
            // Copy data from RegisterViewModel to IdentityUser
            var user = new IdentityUser
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };

            // Store user data in AspNetUsers database table
            var result = await userManager.CreateAsync(user, registerViewModel.Password);

            return new RegisterResultModel
            {
                identityUser = user,
                identityResult = result
            };
        }
    }
}
