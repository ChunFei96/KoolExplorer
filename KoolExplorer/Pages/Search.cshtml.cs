using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoolExplorer.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<ProcessedPreSchool> PreSchools;

        public SearchPageModel(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            PreSchools = _unitOfWork.ProcessedPreSchoolRepository.GetAll().ToList();
            var ma = 0;

            //http://fooplugins.github.io/FooTable/docs/examples/advanced/ajax.html
        }
    }
}
