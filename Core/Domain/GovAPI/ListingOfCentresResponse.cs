using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.GovAPI
{
    public partial class ListingOfCentresResponse
    {
        [Display(Name = "Tp Code")]
        public string tp_code { get; set; }

        [Display(Name = "Centre Code")]
        public string centre_code { get; set; }

        [Display(Name = "Centre Name")]
        public string centre_name { get; set; }

        [Display(Name = "Organisation Code")]
        public string organisation_code { get; set; }

        [Display(Name = "Organisation Description")]
        public string organisation_description { get; set; }

        [Display(Name = "Service Model")]
        public string service_model { get; set; }

        [Display(Name = "Centre Contact No")]
        public string centre_contact_no { get; set; }

        [Display(Name = "Centre Email Address")]
        public string centre_email_address { get; set; }

        [Display(Name = "Centre Address")]
        public string centre_address { get; set; }

        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        [Display(Name = "Centre Website")]
        public string centre_website { get; set; }

        [Display(Name = "Infant Vacancy")]
        public string infant_vacancy { get; set; }

        [Display(Name = "Pg Vacancy")]
        public string pg_vacancy { get; set; }

        [Display(Name = "N1 Vacancy")]
        public string n1_vacancy { get; set; }

        [Display(Name = "N2 Vacancy")]
        public string n2_vacancy { get; set; }

        [Display(Name = "K1 Vacancy")]
        public string k1_vacancy { get; set; }

        [Display(Name = "K2 Vacancy")]
        public string k2_vacancy { get; set; }

        [Display(Name = "Food Offered")]
        public string food_offered { get; set; }

        [Display(Name = "Second Language Offered")]
        public string second_language_offered { get; set; }

        [Display(Name = "Spark Certified")]
        public string spark_certified { get; set; }

        [Display(Name = "Weekday Full Day")]
        public string weekday_full_day { get; set; }

        [Display(Name = "Saturday")]
        public string saturday { get; set; }

        [Display(Name = "Scheme Type")]
        public string scheme_type { get; set; }

        [Display(Name = "Extended Operating Hours")]
        public string extended_operating_hours { get; set; }

        [Display(Name = "Provision Of Transport")]
        public string provision_of_transport { get; set; }

        [Display(Name = "Government Subsidy")]
        public string government_subsidy { get; set; }

        [Display(Name = "Gst Registration")]
        public string gst_registration { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime last_updated { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }
    }
}
