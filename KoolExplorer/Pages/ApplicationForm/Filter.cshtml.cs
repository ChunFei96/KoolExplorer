using System;
using System.Threading.Tasks;
using Core.Domain.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Filter;

namespace KoolExplorer.Pages.ApplicationForm
{
    public class FilterDropDownModel : PageModel
    {
        private readonly IFilterService _filterService;
        public FilterDropDownModel(IFilterService filterService)
        {
            _filterService = filterService;
        }
        public async Task<IActionResult> OnPostFilter([FromBody] FilterModel filterModel)
        {
            switch (filterModel.Target)
            {
                case "District":
                    var test = new JsonResult(await _filterService.GetDistrictList(filterModel.Value.ToString()));
                    return test;
                case "PreSchool":
                    return new JsonResult(await _filterService.GetPreSchoolList(Convert.ToInt32(filterModel.Value)));
                case "Programme":
                    return new JsonResult(await _filterService.GetProgrammeList(Convert.ToInt32(filterModel.Value)));
            }
            return null;
        }
    }
}
