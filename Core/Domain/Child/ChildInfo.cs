using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoolExplorer.Model
{
    public class ChildInfo
    {
        public string Author { get; set; }
        public CitizenshipEnum Citizenship { get; set; }
        public string Race { get; set; }
        public string BirthCertification { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }
    }

    public enum CitizenshipEnum
    {
        Foreign,
        PR,
        Singaporean
    }
}
