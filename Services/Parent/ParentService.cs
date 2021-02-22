using Core.Domain.Parent;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parent
{
    public partial class ParentService : IParentService
    {

        public ParentService()
        {
        }

        public virtual async Task<SubmissionResponse> SubmitApplicationForm(AdmissionModel admissionModel)
        {
            return new SubmissionResponse();
        }
    }
}
