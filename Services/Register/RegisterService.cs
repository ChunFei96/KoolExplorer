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
        private readonly RoleManager<IdentityRole> roleManager;
        public RegisterService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
            // Assign role to the user
            var result2 = await userManager.AddToRoleAsync(user, registerViewModel.RoleName);

            return new RegisterResultModel
            {
                identityUser = user,
                identityResult = result
            };
        }
    }
}
