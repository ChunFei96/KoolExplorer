using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class EnrolementRatio : BaseEntity
    {
        public string EnrolementRate { get; set; }
        public char Sex { get; set; }
        public string EducationLevel { get; set; }
        public string Year { get; set; }
    }
}
