using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KoolExplorer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SignInManager<IdentityUser> signInManager;


        public IndexModel(ILogger<IndexModel> logger,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            this.signInManager = signInManager;
        }

        
      

        public IActionResult OnGet()
        {
            if (signInManager.IsSignedIn(User))
                return new RedirectToPageResult("/Dashboard/Dashboard");
            return new RedirectToPageResult("/Login/Login");
        }
    }
}
