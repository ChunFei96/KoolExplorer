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
    }
}
