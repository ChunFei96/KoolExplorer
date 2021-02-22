using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Parent;

namespace Services.Parent
{
    public interface IParentService
    {
        Task<SubmissionResponse> SubmitApplicationForm(AdmissionModel admissionModel);
    }
}
