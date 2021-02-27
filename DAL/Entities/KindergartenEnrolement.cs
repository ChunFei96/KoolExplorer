using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class KindergartenEnrolement : BaseEntity
    {
        public string EnrolementRate { get; set; }
        public string Year { get; set; }
    }
}
