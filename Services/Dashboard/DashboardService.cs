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
    }
}
