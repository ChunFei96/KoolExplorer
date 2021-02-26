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
<<<<<<< HEAD

        private async Task SaveListingOfCentreServices(List<GetListingOfCentreServicesResponse> output)
        {
            try
            {
                if(output != null && output.Count > 0)
                {
                    List<CentreServices> centreServices = new List<CentreServices>();
                    foreach(var data in output)
                    {
                        CentreServices centreService = new CentreServices
                        {
                            Code = data.centre_code,
                            Name = data.centre_name,
                            Licence = data.class_of_licence,
                            Service = data.type_of_service,
                            Level = data.levels_offered,
                            Fee = data.fees,
                            Citizenship = data.type_of_citizenship,
                            Remark = data.remarks,
                            LastUpdated = data.last_updated,
                            Status = 1,
                            CreatedTimeStamp = DateTime.Now
                        };
                        _db.CentreService.Add(centreService);
                    }

                    
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        //pending change the leftover API methods


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
                //SaveListingOfCentreServices(output);

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


=======
>>>>>>> db402c0cc53a5fe6ac1e10f36147291d84dacb38
    }
}
