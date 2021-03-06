using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DAL.Entities
{
    public class DropDownOptions : BaseEntity
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
