using Core.Expansion.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Form
{
    public class AdmissionModel
    {
        public int Id { get; set; }
        public GeneralInformationViewModel GeneralInformationViewModel;

        public ParentsParticularsViewModel ParentsParticularsViewModel;

        public ChildsParticularsViewModel ChildsParticularsViewModel;
        [Display(Name = "Application Status")]
        public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Pending;

        public AdmissionModel()
        {
            GeneralInformationViewModel = new GeneralInformationViewModel();
            ParentsParticularsViewModel = new ParentsParticularsViewModel();
            ChildsParticularsViewModel = new ChildsParticularsViewModel();
        }
    }

    public class GeneralInformationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Area")]
        public int? Area { get; set; }
        public List<SelectListItem> AreaList { get; set; }

        [Display(Name = "District")]
        public int? District { get; set; }
        public IEnumerable<SelectListItem> DistrictList { get; set; }

        [Display(Name = "Pre-School")]
        public int? PreSchool { get; set; }
        public IEnumerable<SelectListItem> PreSchoolList { get; set; }

        [Display(Name = "Programme")]
        public int? Programme { get; set; }
        public IEnumerable<SelectListItem> ProgrammeList { get; set; }

        public IEnumerable<SelectListItem> ProgrammeTimeList { get; set; }

        [Display(Name = "Start Period")]
        public string StartPeriod { get; set; }
    }

    public class ParentsParticularsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Parent/Guardian 1")]
        public string Name1 { get; set; }

        [Display(Name = "Parent/Guardian 1's Passport No.")]
        public string PassportNo1 { get; set; }

        [Display(Name = "Parent/Guardian 1's Mobile No.")]
        public string MobileNo1 { get; set; }

        [Display(Name = "Parent/Guardian 1's Email")]
        public string Email1 { get; set; }

        [Display(Name = "Parent/Guardian 2")]
        public string Name2 { get; set; }

        [Display(Name = "Parent/Guardian 2's Passport No.")]
        public string PassportNo2 { get; set; }

        [Display(Name = "Parent/Guardian 2's Mobile No.")]
        public string MobileNo2 { get; set; }

        [Display(Name = "Parent/Guardian 2's Email")]
        public string Email2 { get; set; }

        [Display(Name = "Home Tel No.")]
        public string HomeTelNo { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Block No.")]
        public string BlockNo { get; set; }

        [Display(Name = "Floor No.")]
        public string FloorNo { get; set; }

        [Display(Name = "Unit No.")]
        public string UnitNo { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Household Income")]
        public string HouseholdIncome { get; set; }
        public IEnumerable<SelectListItem> HouseholdIncomeList { get; set; }

        public ParentsParticularsViewModel()
        {
            HouseholdIncomeList = new List<SelectListItem>
            {
                 new SelectListItem
                {
                    Text = "Please select a household income group",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "$2500 and below",
                    Value = "$2500 and below"
                },
                 new SelectListItem
                {
                    Text = "$2501 - $3000",
                    Value = "$2501 - $3000"
                },
                  new SelectListItem
                {
                    Text = "$3001 - $3500",
                    Value = "$3001 - $3500"
                },
                   new SelectListItem
                {
                    Text = "$3501 - $4000",
                    Value = "$3501 - $4000"
                },
                    new SelectListItem
                {
                    Text = "$4001 - $4500",
                    Value = "$4001 - $4500"
                },

            };
        }
    }

    public class ChildsParticularsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name of Child (as in BC)")]
        public string Name { get; set; }

        [Display(Name = "Child Citizenship")]
        public string Citizenship { get; set; }
        public IEnumerable<SelectListItem> CitizenshipList { get; set; }

        [Display(Name = "Race")]
        public string Race { get; set; }
        public IEnumerable<SelectListItem> RaceList { get; set; }

        [Display(Name = "Birth Cert Number")]
        public string BirthCertNo { get; set; }

        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }

        public ChildsParticularsViewModel()
        {
            GenderList = new List<SelectListItem>
            {
                 new SelectListItem
                {
                    Text = "Male",
                    Value = Convert.ToInt32(Core.Expansion.Enum.Gender.Male).ToString()
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = Convert.ToInt32(Core.Expansion.Enum.Gender.Female).ToString()
                },
            };
        }
    }
    
}
