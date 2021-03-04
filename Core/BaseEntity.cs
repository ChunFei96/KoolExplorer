using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public int? Status { get; set; } = 1;
        public int? CreatedBy { get; set; } 
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTimeStamp { get; set; } = DateTime.Now;
    }
}
