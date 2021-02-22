using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.GovAPI
{
    public partial class GetListingOfCentreServicesResponse
    {
        [Display(Name ="Code")]
        public string centre_code { get; set; }
        [Display(Name = "Level")]
        public string levels_offered { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime? last_updated { get; set; }
        [Display(Name = "Name")]
        public string centre_name { get; set; }
        [Display(Name = "Remark")]
        public string remarks { get; set; }
        [Display(Name = "Service")]
        public string type_of_service { get; set; }
        [Display(Name = "Fee")]
        public string fees { get; set; }
        [Display(Name = "Citizenship")]
        public string type_of_citizenship { get; set; }
        public int _id { get; set; }
        [Display(Name = "Licence")]
        public string class_of_licence { get; set; }
    }
}
