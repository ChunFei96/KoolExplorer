using Core;
using Core.Expansion.Enum;
using System;

namespace DAL.Entities.Form
{
    public class ChildParticularItems : BaseEntity
    {
        public string ChildName { get; set; }
        public string Citizenship { get; set; }
        public string Race { get; set; }
        public string BirthCerNo { get; set; }
        public string DOB { get; set; }
        public Gender? Gender { get; set; }
    }
}
