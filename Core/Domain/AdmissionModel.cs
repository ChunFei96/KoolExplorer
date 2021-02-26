using KoolExplorer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Parent
{
    public partial class AdmissionModel
    {
        public GeneralInfo GeneralInfo { get; set; }
        public ChildInfo ChildInfo { get; set; }
        public ParentInfo ParentInfo { get; set; }
    }
}
