using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DAL.Entities
{
    public class LookUp : BaseEntity
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
