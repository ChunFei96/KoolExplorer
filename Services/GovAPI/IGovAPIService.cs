using Core.Domain.GovAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GovAPI
{
    public interface IGovAPIService
    {
        Task<List<GetListingOfCentreServicesResponse>> GetListOfCentreServices();
    }
}
