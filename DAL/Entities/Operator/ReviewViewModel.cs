using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Operator
{

    public class ReviewViewModel : BaseEntity
    {
        public string applicationNo { get; set; }
        public string parentName { get; set; }
        public string childName { get; set; }
        public string submissionDate { get; set; }
        public string applicationStatus { get; set; }
    }
}
