using Core.Domain;
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

        public virtual async Task<AdmissionModel> EditApplicationForm(string encId)
        {
            return new AdmissionModel();
        }

        public virtual async Task<AdmissionModel> EditApplicationForm(AdmissionModel model)
        {
            return new AdmissionModel();
        }

        public virtual async Task<AdmissionModel> ViewApplicationForm(string encId)
        {
            return new AdmissionModel();
        }

        public virtual async Task<string> ActionToOffer(string encId)
        {
            return "";
        }

        public virtual async Task<AdmissionModel> ActionToOffer(Boolean isAccpet)
        {
            return new AdmissionModel();
        }

        public virtual async Task<string> Search(string encId)
        {
            return "";
        }

        public virtual async Task<SearchModel> Search(SearchModel model)
        {
            return new SearchModel();
        }
    }
}
