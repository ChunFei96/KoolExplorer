using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.DropDown;

namespace KoolExplorer.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDropDownService _dropDownService;
        public List<ProcessedPreSchool> PreSchools;

        public int? Area { get; set; }
        public List<SelectListItem> AreaList { get; set; }
        public int? District { get; set; }
        public IEnumerable<SelectListItem> DistrictList { get; set; }


        public SearchPageModel(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IDropDownService dropDownService)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _dropDownService = dropDownService;
        }

        public void OnGet()
        {
            PreSchools = _unitOfWork.ProcessedPreSchoolRepository.GetAll().ToList();

            //Init dropdownlist
            AreaList = new List<SelectListItem>() { new SelectListItem() { Value = "-", Text = "Please select an Area" } };
            AreaList.AddRange(_dropDownService.GetDropDownByType("Area").Result);

            DistrictList = new List<SelectListItem>() { new SelectListItem() { Value = "-", Text = "Please select a District" } };
        }

        public async Task<IActionResult> OnPostGetPreSchoolById([FromBody] int id)
        {
            var preSchool = _unitOfWork.ProcessedPreSchoolRepository.GetAll().Where(c => c.Id == id).FirstOrDefault();

            if (preSchool != null)
            {
                var d = Newtonsoft.Json.JsonConvert.SerializeObject(preSchool);
                return new JsonResult(d);
            }
            return new JsonResult("nil");
        }

        public async Task<IActionResult> OnPostFilterPreSchoolList([FromBody] int DistrictId)
        {
            //if (ModelState.IsValid)
            //{
            //    formViewModel.GeneralInformationViewModel = generalInformationViewModel;
            //    formViewModel.ParentsParticularsViewModel = parentsParticulars;
            //    formViewModel.ChildsParticularsViewModel = childsParticulars;

            //    _parentService.SubmitApplicationForm(formViewModel);
            //    return new RedirectToPageResult("../AcceptOffer/Index");
            //}

            PreSchools = _unitOfWork.ProcessedPreSchoolRepository.GetAll().Where(c => c.DistrictNo == DistrictId).ToList();

            if (PreSchools.Count > 0)
            {
                return new JsonResult(PreSchools);
            }

            return new JsonResult("nil");
        }

    }
}
