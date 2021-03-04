using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Form;

namespace Services.Parent
{
    public interface IParentService
    {
        void SubmitApplicationForm(AdmissionModel admissionModel);
        Task<AdmissionModel> EditApplicationForm(string encId);
        void EditApplicationForm(AdmissionModel model);
        Task<List<AdmissionModel>> ViewAllApplication(string userId);
        //Task<AdmissionModel> ViewApplicationForm(string encId);
        //Task<string> ActionToOffer(string encId);
        //Task<AdmissionModel> ActionToOffer(Boolean isAccpet);
        //Task<string> Search(string encId);
        //Task<SearchModel> Search(SearchModel model);
    }
}
