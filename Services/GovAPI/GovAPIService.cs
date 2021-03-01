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

        public virtual async Task<List<CentreServices>> GetListOfCentreServices()
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

                var mapList = _mapper.Map<List<CentreServices>>(output);

                // bulk insert to db by auto mapping to CentreServices db model
                _unitOfWork.CentreServicesRepository.BulkInsert(mapList);

                return mapList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<List<EnrolementRatio>> GetNetEnrolmentRatio()
        {
            try
            {
                List<EnrolementRatio> output = new List<EnrolementRatio>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=7b184af5-b718-4c93-b217-c3bb3ab304f4");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<EnrolementRatio>()));

                var mapList = _mapper.Map<List<EnrolementRatio>>(output);

                _unitOfWork.EnrolementRatioRepository.BulkInsert(mapList);

                return mapList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //TODO: 2. Compare CentreServices vs Centres in ssms using query

        public virtual async Task<List<Centres>> GetListingOfCentres()
        {
            try
            {
                List<ListingOfCentresResponse> output = new List<ListingOfCentresResponse>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=ca9cae4b-40b9-4e89-a032-f7d17ff741c6");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<ListingOfCentresResponse>()));


                var mapList = _mapper.Map<List<Centres>>(output);

                _unitOfWork.CentresRepository.BulkInsert(mapList);

                return mapList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<List<KindergartenEnrolement>> GetEnrolmentMOEKindergartens()
        {
            try
            {
                List<MOEEnrolmentResponse> output = new List<MOEEnrolmentResponse>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=4ad866a7-c43a-4645-87fd-fc961c9de78a");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<MOEEnrolmentResponse>()));

                var mapList = _mapper.Map<List<KindergartenEnrolement>>(output);
                _unitOfWork.KindergartenEnrolementRepository.BulkInsert(mapList);

                return mapList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
