using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class CentreServices
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Remark { get; set; }
        public string Service { get; set; }
        public string Fee { get; set; }
        public string Citizenship { get; set; }
        public string Licence { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTimeStamp { get; set; }
    }
}
