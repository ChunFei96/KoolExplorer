using Core.Domain.GovAPI;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Services.GovAPI
{
    public interface IGovAPIService
    {
        Task<List<CentreServices>> GetListOfCentreServices();
        Task<List<Centres>> GetListingOfCentres();
        Task<List<KindergartenEnrolement>> GetEnrolmentMOEKindergartens();
        Task<List<EnrolementRatio>> GetNetEnrolmentRatio();

        Task<string> ProcessedPreSchool();
        Task<List<SelectListItem>> GetDistrictList(string area);  //Retrieve "District" Dropdown options using "area" as  param
        Task<List<SelectListItem>> GetPreSchoolList(int districtNo);  //Retrieve "PreSchools" Dropdown options using "districtNo" as  param

    }
}
