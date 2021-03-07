using DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class FilterService : IFilterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<List<SelectListItem>> GetDistrictList(string area)
        {
            var AreaList = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(area))
            {
                /*
                 * 1. West
                 * 2. Central
                 * 3. East
                 * 4. North
                 * 5. North East
                */

                List<int> districtNo = new List<int>();
                List<string> districtNames = new List<string>();

                if (area.ToUpper().Equals("WEST"))
                {
                    districtNo = new List<int>() { 5, 10, 21, 22, 23, 24 };
                    districtNames = new List<string>() { "South West", "Central - Near Orchard", "Central West", "Far West", "North West", "Far North West" };
                }
                else if (area.ToUpper().Equals("CENTRAL"))
                {
                    districtNo = new List<int>() { 3, 4, 12, 14, 15, 20 };
                    districtNames = new List<string>() { "Central South", "South", "Central", "Central East", "East Coast", "Central North" };
                }
                else if (area.ToUpper().Equals("EAST"))
                {
                    districtNo = new List<int>() { 14, 16, 17, 18 };
                    districtNames = new List<string>() { "Central East", "Upper East Coast", "Far East", "Far East 2" };
                }
                else if (area.ToUpper().Equals("NORTH"))
                {
                    districtNo = new List<int>() { 24, 25, 27 };
                    districtNames = new List<string>() { "Far North West", "Far North", "Far North 2" };
                }
                else if (area.ToUpper().Equals("NORTH EAST"))
                {
                    districtNo = new List<int>() { 19, 20, 27, 28 };
                    districtNames = new List<string>() { "North East", "Central North", "Far North", "North East" };
                }

                if (districtNo.Count() > 0)
                {
                    for (var i = 0; i < districtNo.Count(); i++)
                    {
                        SelectListItem listItem = new SelectListItem();
                        listItem.Text = districtNames[i];
                        listItem.Value = districtNo[i].ToString();
                        AreaList.Add(listItem);
                    }
                }
            }

            return AreaList;
        }

        public virtual async Task<List<SelectListItem>> GetPreSchoolList(int districtNo)
        {
            var AreaList = new List<SelectListItem>();

            if (districtNo >= 1 && districtNo <= 28)
            {
                var preSchools = _unitOfWork.ProcessedPreSchoolRepository.GetAll().Where(c => c.DistrictNo == districtNo).ToList();

                if (preSchools.Count() > 0)
                {
                    foreach (var i in preSchools)
                    {
                        SelectListItem listItem = new SelectListItem();
                        listItem.Text = i.Name;
                        listItem.Value = i.Id.ToString();
                        AreaList.Add(listItem);
                    }
                }
            }

            return AreaList;
        }

        public virtual async Task<List<SelectListItem>> GetProgrammeList(int preSchoolId)
        {
            var AreaList = new List<SelectListItem>();

            var programmes = _unitOfWork.ProgrammeRepository.GetAll().Where(c => c.PreSchoolId == preSchoolId).ToList();

            if (programmes.Count() > 0)
            {
                foreach (var i in programmes)
                {
                    SelectListItem listItem = new SelectListItem();
                    listItem.Text = i.Description;
                    listItem.Value = i.Id.ToString();
                    AreaList.Add(listItem);
                }
            }

            return AreaList;
        }
    }
}
