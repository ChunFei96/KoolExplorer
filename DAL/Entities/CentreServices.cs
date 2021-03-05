using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class CentreServices : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Remark { get; set; }
        public string Service { get; set; }
        public string Fee { get; set; }
        public string Citizenship { get; set; }
        public string Licence { get; set; }
        public bool Processed { get; set; } = false;
    }
}
