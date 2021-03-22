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
        Task<List<ReviewViewModel>> RetrieveApplications(int PreSchoolID);
    }
}
