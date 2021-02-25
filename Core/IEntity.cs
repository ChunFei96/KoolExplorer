using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
    }
}
