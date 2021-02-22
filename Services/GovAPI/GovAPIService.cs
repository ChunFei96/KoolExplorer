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

        private readonly EFDbContext _db;

        public GovAPIService(EFDbContext db)
        {
            _db = db;
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

                SaveListingOfCentreServices(output);

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

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
    }
}
