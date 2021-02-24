using Core.Domain.GovAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GovAPI
{
    public interface IGovAPIService
    {
        Task<List<GetListingOfCentreServicesResponse>> GetListOfCentreServices();
        Task<List<ListingOfCentresResponse>> GetListingOfCentres();
        Task<List<MOEEnrolmentResponse>> GetEnrolmentMOEKindergartens();
        Task<List<NetEnrolementRatioResponse>> GetNetEnrolmentRatio();
    }
}
