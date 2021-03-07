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
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


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
                var dbTable = _unitOfWork.CentreServicesRepository;

                var GovAPI_lookup = _unitOfWork.LookUpRepository.GetAll().Where(c => c.Text.Equals("GovAPI")).FirstOrDefault();
                var isNextUpdates = false;
                isNextUpdates = DateTime.Today == Convert.ToDateTime(GovAPI_lookup.Value);

                if (dbTable.GetAll().Count == 0 || isNextUpdates)
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
                else
                {
                    return null;
                }
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
                var dbTable = _unitOfWork.EnrolementRatioRepository;

                var GovAPI_lookup = _unitOfWork.LookUpRepository.GetAll().Where(c => c.Text.Equals("GovAPI")).FirstOrDefault();
                var isNextUpdates = false;
                isNextUpdates = DateTime.Today == Convert.ToDateTime(GovAPI_lookup.Value);

                if (dbTable.GetAll().Count == 0 || isNextUpdates)
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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public virtual async Task<List<Centres>> GetListingOfCentres()
        {
            try
            {
                var dbTable = _unitOfWork.CentresRepository;

                var GovAPI_lookup = _unitOfWork.LookUpRepository.GetAll().Where(c => c.Text.Equals("GovAPI")).FirstOrDefault();
                var isNextUpdates = false;
                isNextUpdates = DateTime.Today == Convert.ToDateTime(GovAPI_lookup.Value);

                if (dbTable.GetAll().Count == 0 || isNextUpdates)
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
                else
                {
                    return null;
                }
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
                var dbTable = _unitOfWork.KindergartenEnrolementRepository;

                var GovAPI_lookup = _unitOfWork.LookUpRepository.GetAll().Where(c => c.Text.Equals("GovAPI")).FirstOrDefault();
                var isNextUpdates = false;
                isNextUpdates = DateTime.Today == Convert.ToDateTime(GovAPI_lookup.Value);

                if (dbTable.GetAll().Count == 0 || isNextUpdates)
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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //Pending : a place to call the method, Centres & CentreServices must have data
        //-> await ProcessedPreSchool(); 
        public virtual async Task<string> ProcessedPreSchool()
        { 
            try
            {
                var Centres_db  =   from c in _unitOfWork.CentresRepository.GetAll().ToList() select c;
                var CentresList =   from c in Centres_db
                                    group c by c.Name into g
                                    select new
                                    {
                                        Name = g.Key,
                                        Count = g.Count()
                                    };


                var CentreServices_db = from c in _unitOfWork.CentreServicesRepository.GetAll().ToList() select c;
                var CentreServicesList = from c in CentreServices_db
                                         group c by c.Name into g
                                         select new
                                         {
                                            Name = g.Key,
                                            Count = g.Count()
                                         };

                var duplicateRecords = new List<string>();

                var asdas = CentresList.Where(c => c.Count > 1).ToList(); //test

                foreach (var i in CentresList)
                {
                    if(!duplicateRecords.Contains(i.Name))
                    {
                        var data = Centres_db.Where(c => c.Name.Equals(i.Name)).ToList();
                        var getFirst = data.FirstOrDefault();

                        if (getFirst != null)
                        {
                            var CS_data = CentreServices_db.Where(m => m.Name.ToUpper().Equals(getFirst.Name.ToUpper())).FirstOrDefault();

                            ProcessedPreSchool pc = new ProcessedPreSchool();
                            pc.TPCode = getFirst.TPCode;
                            pc.Code = getFirst.Code;
                            pc.Name = getFirst.Name;
                            pc.OrganisationCode = getFirst.OrganisationCode;
                            pc.OrganisationDescription = getFirst.OrganisationDescription;

                            if (CS_data != null)
                            {
                                pc.ProgrammeTime = CS_data.Service;
                                pc.Fee = CS_data.Fee;
                                pc.Licence = CS_data.Licence;
                            }
                            else
                            {
                                pc.ProgrammeTime = "Full Day"; //Default as 'FD'
                                pc.Fee = "na";
                                pc.Licence = "na";
                            }
                            pc.ServiceModel = getFirst.ServiceModel;
                            pc.ContactNo = getFirst.ContactNo;
                            pc.Email = getFirst.Email;
                            pc.Website = getFirst.Website;
                            pc.Address = getFirst.Address;
                            pc.PostalCode = getFirst.PostalCode;
                            pc.FoodOffered = getFirst.FoodOffered;
                            pc.SecondLanguageOffered = getFirst.SecondLanguageOffered;
                            pc.SparkCertified = getFirst.SparkCertified;
                            pc.SchemeType = getFirst.SchemeType;
                            pc.ProvisionOfTransport = getFirst.ProvisionOfTransport;
                            pc.GovernmentSubsidy = getFirst.GovernmentSubsidy;
                            pc.GstRegistration = getFirst.GstRegistration;
                            pc.Remarks = getFirst.Remarks;
                            pc.DistrictNo = DistrictProcessing(getFirst.PostalCode);
                            _unitOfWork.ProcessedPreSchoolRepository.Insert(pc);

                            getFirst.Processed = true;
                            _unitOfWork.CentresRepository.Update(getFirst);

                            //LINQ 
                            //https://stackoverflow.com/questions/7325278/group-by-in-linq/7325306


                            //https://stackoverflow.com/questions/13650257/adding-a-foreign-key-with-code-first-migration
                            //Issue: Programme PK cannot use auto Migration, need change to physical declare


                            if (!string.IsNullOrEmpty(getFirst.InfantVacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "InfantVacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }
                            if (!string.IsNullOrEmpty(getFirst.K1Vacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "K1Vacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }
                            if (!string.IsNullOrEmpty(getFirst.K2Vacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "K2Vacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }
                            if (!string.IsNullOrEmpty(getFirst.N1Vacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "N1Vacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }
                            if (!string.IsNullOrEmpty(getFirst.N2Vacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "N2Vacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }
                            if (!string.IsNullOrEmpty(getFirst.PgVacancy))
                            {
                                Programme pg = new Programme();
                                pg.PreSchoolId = pc.Id;
                                pg.Description = "PgVacancy";
                                _unitOfWork.ProgrammeRepository.Insert(pg);
                            }

                            duplicateRecords.Add(i.Name);
                        }
                    }

                    //DONE: Function to convert Postal Code to District cat
                    //https://en.m.wikipedia.org/wiki/Postal_codes_in_Singapore
                    //https://www.mingproperty.sg/singapore-district-code/
                }
                return "done";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private int DistrictProcessing(string digits)
        {
            int results = -1;

            if (!string.IsNullOrEmpty(digits) && int.TryParse(digits.Substring(0, 2), out int firsttwo))
            {
                int PostalDistrict = 1;

                if (firsttwo >= 1 && firsttwo <= 6)
                {
                    PostalDistrict = 1;
                }
                else if (firsttwo == 7 || firsttwo == 8)
                {
                    PostalDistrict = 2;
                }
                else if (firsttwo >= 14 && firsttwo <= 16)
                {
                    PostalDistrict = 3;
                }
                else if (firsttwo == 9 || firsttwo == 10)
                {
                    PostalDistrict = 4;
                }
                else if (firsttwo >= 11 && firsttwo <= 13)
                {
                    PostalDistrict = 5;
                }
                else if (firsttwo == 17)
                {
                    PostalDistrict = 6;
                }
                else if (firsttwo == 18 || firsttwo == 19)
                {
                    PostalDistrict = 7;
                }
                else if (firsttwo == 20 || firsttwo == 21)
                {
                    PostalDistrict = 8;
                }
                else if (firsttwo == 22 || firsttwo == 23)
                {
                    PostalDistrict = 9;
                }
                else if (firsttwo >= 24 && firsttwo <= 27)
                {
                    PostalDistrict = 10;
                }
                else if (firsttwo >= 28 && firsttwo <= 30)
                {
                    PostalDistrict = 11;
                }
                else if (firsttwo >= 31 && firsttwo <= 33)
                {
                    PostalDistrict = 12;
                }
                else if (firsttwo >= 34 && firsttwo <= 37)
                {
                    PostalDistrict = 13;
                }
                else if (firsttwo >= 38 && firsttwo <= 41)
                {
                    PostalDistrict = 14;
                }
                else if (firsttwo >= 42 && firsttwo <= 45)
                {
                    PostalDistrict = 15;
                }
                else if (firsttwo >= 46 && firsttwo <= 48)
                {
                    PostalDistrict = 16;
                }
                else if (firsttwo >= 49 && firsttwo <= 51)
                {
                    PostalDistrict = 17;
                }
                else if (firsttwo >= 51 && firsttwo <= 52)
                {
                    PostalDistrict = 18;
                }
                else if ((firsttwo >= 53 && firsttwo <= 55) || firsttwo == 82)
                {
                    PostalDistrict = 19;
                }
                else if (firsttwo >= 56 && firsttwo <= 57)
                {
                    PostalDistrict = 20;
                }
                else if (firsttwo >= 58 && firsttwo <= 59)
                {
                    PostalDistrict = 21;
                }
                else if (firsttwo >= 60 && firsttwo <= 64)
                {
                    PostalDistrict = 22;
                }
                else if (firsttwo >= 65 && firsttwo <= 68)
                {
                    PostalDistrict = 23;
                }
                else if (firsttwo >= 69 && firsttwo <= 71)
                {
                    PostalDistrict = 24;
                }
                else if (firsttwo >= 72 && firsttwo <= 73)
                {
                    PostalDistrict = 25;
                }
                else if (firsttwo >= 77 && firsttwo <= 78)
                {
                    PostalDistrict = 26;
                }
                else if (firsttwo >= 75 && firsttwo <= 76)
                {
                    PostalDistrict = 27;
                }
                else if (firsttwo >= 79 && firsttwo <= 80)
                {
                    PostalDistrict = 28;
                }

                results = PostalDistrict;
            }
            return results;
        }
    }
}
