using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public interface IFilterService
    {
        Task<List<SelectListItem>> GetDistrictList(string area);  //Retrieve "District" Dropdown options using "area" as  param
        Task<List<SelectListItem>> GetPreSchoolList(int districtNo);  //Retrieve "PreSchools" Dropdown options using "districtNo" as  param
        Task<List<SelectListItem>> GetProgrammeList(int preSchoolId); //Retrieve "Programmes" Dropdown options using "preschoolId" as  param
    }
}
