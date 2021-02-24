using AutoMapper;
using Core.Domain.GovAPI;
using DAL;
using DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Services.GovAPI
{
    public partial class GovAPIService : IGovAPIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GovAPIService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<List<GetListingOfCentreServicesResponse>> GetListOfCentreServices()
        {
            try
            {
                List<GetListingOfCentreServicesResponse> output = new List<GetListingOfCentreServicesResponse>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=53a18f6c-1032-44eb-af44-d9babb41d9ef");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<GetListingOfCentreServicesResponse>()));

                foreach (var row in output)
                    _unitOfWork.CentreServicesRepository.Insert(_mapper.Map<CentreServices>(row));

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
