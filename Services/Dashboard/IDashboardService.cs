using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dashboard
{
    public interface IDashboardService
    {
        Dictionary<string, int> GetSparkCertifiedRatio();
        string GetOrganisationRatio();
        string GetServiceOfferedRatio();
        Dictionary<string, int> GetGenderRatio(string userId);
        string GetAgeRatio(string userId);
        string GetCitizenshipRatio(string userId);
    }
}
