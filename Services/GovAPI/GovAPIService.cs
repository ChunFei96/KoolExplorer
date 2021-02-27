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


        //TODO: Method to compare CentreServices vs Centres before saving into db

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

        public virtual async Task<List<NetEnrolementRatioResponse>> GetNetEnrolmentRatio()
        {
            try
            {
                List<NetEnrolementRatioResponse> output = new List<NetEnrolementRatioResponse>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=7b184af5-b718-4c93-b217-c3bb3ab304f4");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<NetEnrolementRatioResponse>()));

                //TODO: Save the API data into db
                // bulk insert to db by auto mapping to CentreServices db model
                _unitOfWork.EnrolementRatioRepository.BulkInsert(_mapper.Map<List<NetEnrolementRatioResponse>>(output));

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<List<ListingOfCentresResponse>> GetListingOfCentres()
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

                //TODO: Save the API data into db
                //SaveListingOfCentreServices(output);

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<List<MOEEnrolmentResponse>> GetEnrolmentMOEKindergartens()
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

                //TODO: Save the API data into db
                //SaveListingOfCentreServices(output);

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
