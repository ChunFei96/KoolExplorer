using Core;
using System;

namespace DAL.Entities.Form
{
    public class GeneralInformationItems : BaseEntity
    {
        public int? Area { get; set; }
        public int? District { get; set; }
        public int? PreSchool { get; set; }
        public int? Programme { get; set; }
        public string StartPeriod { get; set; }
    }
}
