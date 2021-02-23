using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.GovAPI
{
    public class CentreServices : BaseEntity
    {
        public string centre_code { get; set; }
        public string centre_name { get; set; }
        public string levels_offered { get; set; }
        public string remarks { get; set; }
        public string type_of_service { get; set; }
        public string fees { get; set; }
        public string type_of_citizenship { get; set; }
        public string class_of_licence { get; set; }
        public DateTime? last_updated { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTimeStamp { get; set; }
    }
}
