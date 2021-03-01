using Core.Domain.GovAPI;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GovAPI
{
    public interface IGovAPIService
    {
        Task<List<CentreServices>> GetListOfCentreServices();
        Task<List<Centres>> GetListingOfCentres();
        Task<List<KindergartenEnrolement>> GetEnrolmentMOEKindergartens();
        Task<List<EnrolementRatio>> GetNetEnrolmentRatio();
    }
}
