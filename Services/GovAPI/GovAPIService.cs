using Core.Domain.GovAPI;
using DAL;
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
        public GovAPIService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<List<CentreServices>> GetListOfCentreServices()
        {
            try
            {
                List<CentreServices> output = new List<CentreServices>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.gov.sg/api/action/datastore_search?resource_id=53a18f6c-1032-44eb-af44-d9babb41d9ef");
                request.Method = "Get";

                HttpWebResponse response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new System.Exception();

                var responseData = JsonConvert.DeserializeObject<GovAPIResponse>(new StreamReader(response.GetResponseStream()).ReadToEnd());
                responseData.result.records.ForEach(a => output.Add(a.ToObject<CentreServices>()));

                foreach(var row in output)
                    _unitOfWork.CentreServicesRepository.Insert(row);

                return output;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
