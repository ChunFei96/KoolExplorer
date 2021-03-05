using Core.Expansion.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public Status? Status { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
        public DateTime? ModifiedTimeStamp { get; set; } = DateTime.Now;
    }
}
