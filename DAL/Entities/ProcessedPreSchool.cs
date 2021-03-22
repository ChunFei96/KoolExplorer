using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DAL.Entities
{
    public class ProcessedPreSchool : BaseEntity 
    {
        public string TPCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrganisationCode { get; set; }
        public string OrganisationDescription { get; set; }
        public string ProgrammeTime { get; set; }
        public string Fee { get; set; }
        public string Licence { get; set; }
        public string ServiceModel { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string FoodOffered { get; set; }
        public string SecondLanguageOffered { get; set; }
        public string SparkCertified { get; set; }
        public string SchemeType { get; set; }
        public string ProvisionOfTransport { get; set; }
        public string GovernmentSubsidy { get; set; }
        public string GstRegistration { get; set; }
        public string Remarks { get; set; }
        public int DistrictNo { get; set; }
        public string OperatorId { get; set; }
        //public List<Programme> ProgrammeType { get; set; }
    }
}
