using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Login
{
    public class RegisterResultModel
    {
        public IdentityUser identityUser;
        public IdentityResult identityResult;
    }
}
