using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Centres : BaseEntity
    {
        public string TPCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrganisationCode { get; set; }
        public string OrganisationDescription { get; set; }
        public string ServiceModel { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Website { get; set; }
        public string InfantVacancy { get; set; }
        public string PgVacancy { get; set; }
        public string N1Vacancy { get; set; }
        public string N2Vacancy { get; set; }
        public string K1Vacancy { get; set; }
        public string K2Vacancy { get; set; }
        public string FoodOffered { get; set; }
        public string SecondLanguageOffered { get; set; }
        public string SparkCertified { get; set; }
        public string WeekdayFullDay { get; set; }
        public string Saturday { get; set; }
        public string SchemeType { get; set; }
        public string ExtendedOperatingHours { get; set; }
        public string ProvisionOfTransport { get; set; }
        public string GovernmentSubsidy { get; set; }
        public string GstRegistration { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Remarks { get; set; }
        //public DateTime? LastUpdated { get; set; }
        //public int? Status { get; set; }
        //public int? CreatedBy { get; set; }
        //public int? ModifiedBy { get; set; }
        //public DateTime? ModifiedTimeStamp { get; set; }
    }
}
