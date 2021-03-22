using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<string, int> GetSparkCertifiedRatio()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            try
            {
                dict.Add("Yes", _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.SparkCertified.Equals("Yes")).Count());
                dict.Add("No", _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.SparkCertified.Equals("No")).Count());
            }
            catch(Exception e)
            {
                return null;
            }

            return dict;
        }

        public string GetOrganisationRatio()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            try
            {
                List<string> Keys = new List<string>();
                Keys = _unitOfWork.ProcessedPreSchoolRepository.Get(p => !String.IsNullOrEmpty(p.OrganisationDescription)).ToList().Select(x => x.OrganisationDescription).ToList();

                foreach(var key in Keys)
                {
                    if (dict.ContainsKey(key))
                        dict[key] += 1;
                    else
                        dict.Add(key, 1);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return JsonConvert.SerializeObject(dict);
        }

        public string GetServiceOfferedRatio()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            try
            {
                var InfantVacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.InfantVacancy) && p.InfantVacancy != "na" ).ToList().Select(x => x.InfantVacancy).ToList();
                var PgVacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.PgVacancy) && p.PgVacancy != "na").ToList().Select(x => x.PgVacancy).ToList();
                var N1Vacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.N1Vacancy) && p.N1Vacancy != "na").ToList().Select(x => x.N1Vacancy).ToList();
                var N2Vacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.N2Vacancy) && p.N2Vacancy != "na").ToList().Select(x => x.N2Vacancy).ToList();
                var K1Vacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.K1Vacancy) && p.K1Vacancy != "na").ToList().Select(x => x.K1Vacancy).ToList();
                var K2Vacancy = _unitOfWork.CentresRepository.Get(p => !String.IsNullOrEmpty(p.K2Vacancy) && p.K2Vacancy != "na").ToList().Select(x => x.K2Vacancy).ToList();

                dict.Add("Infant", InfantVacancy.Count());
                dict.Add("Pg", PgVacancy.Count());
                dict.Add("N1", N1Vacancy.Count());
                dict.Add("N2", N2Vacancy.Count());
                dict.Add("K1", K1Vacancy.Count());
                dict.Add("K2", K2Vacancy.Count());

            }
            catch (Exception e)
            {
                return null;
            }

            return JsonConvert.SerializeObject(dict);
        }
        public Dictionary<string, int> GetGenderRatio(string userId)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Male", 0);
            dict.Add("Female", 0);

            try
            {
                var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
                var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
                var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.Status == Core.Expansion.Enum.Status.Active).ToList();
                if(applications != null && applications.Count() > 0)
                {
                    foreach(var app in applications)
                    {
                        var child = _unitOfWork.ChildParticularItemsRepository.Get(c => c.Id == app.childParticularItemsId).FirstOrDefault();
                        dict[child.Gender.Value.ToString()] += 1;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return dict;
        }

        public string GetAgeRatio(string userId)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> Ages = new List<int>();
            try
            {
                var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
                var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
                var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.Status == Core.Expansion.Enum.Status.Active).ToList();
                if (applications != null && applications.Count() > 0)
                {
                    foreach (var app in applications)
                    {
                        var child = _unitOfWork.ChildParticularItemsRepository.Get(c => c.Id == app.childParticularItemsId).FirstOrDefault();

                        var today = DateTime.Today;

                        // Calculate the age.
                        var Age = today.Year - DateTime.Parse(child.DOB).Year;

                        // Go back to the year in which the person was born in case of a leap year
                        if (DateTime.Parse(child.DOB).Date > today.AddYears(-Age)) Age--;

                        Ages.Add(Age);
                    }

                    if(Ages != null && Ages.Count() > 0)
                    {
                        foreach(var age in Ages)
                        {
                            if (dict.ContainsKey(age))
                                dict[age] += 1;
                            else
                                dict.Add(age, 1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return JsonConvert.SerializeObject(dict);
        }

        public string GetCitizenshipRatio(string userId)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Foreigner", 0);
            dict.Add("PR", 0);
            dict.Add("Singaporean", 0);
            try
            {
                var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
                var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
                var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.Status == Core.Expansion.Enum.Status.Active).ToList();
                if (applications != null && applications.Count() > 0)
                {
                    foreach (var app in applications)
                    {
                        var child = _unitOfWork.ChildParticularItemsRepository.Get(c => c.Id == app.childParticularItemsId).FirstOrDefault();
                        Core.Expansion.Enum.Citizenship citizenship= (Core.Expansion.Enum.Citizenship)Convert.ToInt32(child.Citizenship);
                        dict[citizenship.ToString()] += 1;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return JsonConvert.SerializeObject(dict);
        }
    }
}
