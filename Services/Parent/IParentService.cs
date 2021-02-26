using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Parent;

namespace Services.Parent
{
    public interface IParentService
    {
        Task<SubmissionResponse> SubmitApplicationForm(AdmissionModel admissionModel);
        Task<AdmissionModel> EditApplicationForm(string encId);
        Task<AdmissionModel> EditApplicationForm(AdmissionModel model);
        Task<AdmissionModel> ViewApplicationForm(string encId);
        Task<string> ActionToOffer(string encId);
        Task<AdmissionModel> ActionToOffer(Boolean isAccpet);
        Task<string> Search(string encId);
        Task<SearchModel> Search(SearchModel model);
    }
}
