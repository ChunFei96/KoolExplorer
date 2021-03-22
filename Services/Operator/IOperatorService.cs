using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Form;
using DAL.Entities.Operator;

namespace Services.Operator
{
    public interface IOperatorService
    {
        Task<List<ReviewViewModel>> RetrieveApplications(string userId);
        void ReviewApplication(int id, string action);
        Task<int> TotalApplications(string userId);
        Task<int> TotalAccepted(string userId);
        Task<int> TotalPending(string userId);
     
    }
}
