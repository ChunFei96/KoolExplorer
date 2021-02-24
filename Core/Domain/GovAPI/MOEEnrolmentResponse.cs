using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.GovAPI
{
    public partial class MOEEnrolmentResponse
    {
        public int _id { get; set; }

        [Display(Name = "Enrolment")]
        public string enrolment { get; set; }

        [Display(Name = "Year")]
        public string year { get; set; }
    }
}
