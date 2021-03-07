using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DropDown
{
    public class DropDownService : IDropDownService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DropDownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SelectListItem>> GetDropDownByType(string type)
        {
            switch (type)
            {
                case "PreSchool":
                    List<ProcessedPreSchool> preSchooldropdownList = _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.Status == Core.Expansion.Enum.Status.Active).ToList();
                    return new SelectList(preSchooldropdownList, "Id", "Name").ToList();
                case "Programme":
                    List<Programme> programmeDropdownList = _unitOfWork.ProgrammeRepository.Get(p => p.Status == Core.Expansion.Enum.Status.Active).ToList();
                    return new SelectList(programmeDropdownList, "Id", "Description").ToList();
                default:
                    List<DropDownOptions> dropdownList = _unitOfWork.DropDownOptionsRepository.Get(d => d.Type.Equals(type)).ToList();
                    return new SelectList(dropdownList, "Code", "Description").ToList();
            }
        }
    }
}
