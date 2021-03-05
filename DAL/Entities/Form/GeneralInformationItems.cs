using Core;
using System;

namespace DAL.Entities.Form
{
    public class GeneralInformationItems : BaseEntity
    {
        public string Area { get; set; }
        public string District { get; set; }
        public string PreSchool { get; set; }
        public string Programme { get; set; }
        public string ProgrammeTime { get; set; }
        public DateTime? StartPeriod { get; set; }
    }
}
