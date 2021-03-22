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
        //void SubmitApplicationForm(AdmissionModel admissionModel);
        //Task<AdmissionModel> EditApplicationForm(string encId);
        //Task<AdmissionModel> EditApplicationForm(AdmissionModel model);
        //Task<AdmissionModel> ViewApplicationForm(string encId);
        //Task<string> ActionToOffer(string encId);
        //Task<AdmissionModel> ActionToOffer(Boolean isAccpet);
        //Task<string> Search(string encId);
        //Task<SearchModel> Search(SearchModel model);

        Task SubmitApplicationFormAsync(AdmissionModel admissionModel);
        Task<AdmissionModel> EditApplicationForm(string encId);
        Task EditApplicationForm(AdmissionModel model);
        Task<List<AdmissionModel>> ViewAllApplication(string userId);
        Task AcceptApplicationForm(string encId);
        Task RejectApplicationForm(string encId);

        //Functions to display the total in Dashboard
        Task<int> getTotalSchools();
        Task<int> getTotalSubmissions(string createdBy);
        Task<int> getTotalAcceptances(string createdBy);
    }
}
