using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.GovAPI
{
    public partial class NetEnrolementRatioResponse
    {
        public int _id { get; set; }

        [Display(Name = "Total Net Enrolment Rate")]
        public string total_net_enrolment_rate { get; set; }

        [Display(Name = "Sex")]
        public string sex { get; set; }

        [Display(Name = "Level Of Education")]
        public string level_of_education { get; set; }

        [Display(Name = "Year")]
        public string year { get; set; }
    }
}
