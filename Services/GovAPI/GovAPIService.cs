using AutoMapper;
using Core.Configuration;
using Core.Domain.GovAPI;
using DAL;
using DAL.Entities;
using Microsoft.Extensions.Options;
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
        private readonly GovAPIURLConfig _govAPIURLConfig;

        public GovAPIService(IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<GovAPIURLConfig> govAPIURLConfig)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _govAPIURLConfig = govAPIURLConfig.Value;
        }

        public virtual async Task<List<GetListingOfCentreServicesResponse>> GetListOfCentreServices()
        {
            try
            {
                List<GetListingOfCentreServicesResponse> output = new List<GetListingOfCentreServicesResponse>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_govAPIURLConfig.ListingOfCentreServices);
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<GetListingOfCentreServicesResponse>()));

                // bulk insert to db by auto mapping to CentreServices db model
                _unitOfWork.CentreServicesRepository.BulkInsert(_mapper.Map<List<CentreServices>>(output));

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
