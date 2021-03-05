using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DAL.Entities
{
    public class Programme : BaseEntity 
    {
        public int PreSchoolId { get; set; }
        public string Description { get; set; }
    }
}
