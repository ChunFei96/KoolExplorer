using Core.Domain.Form;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using System.Collections.Generic;
using DAL.Entities.Form;
using DAL.Entities.Operator;
using DAL.Entities;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Services.Operator 
{
    public partial class OperatorService : IOperatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OperatorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<List<ReviewViewModel>> RetrieveApplications(int PreSchoolID)
        {
            var results = new List<ReviewViewModel>();
            var data = _unitOfWork.GeneralInformationItemsRepository.Get(c => c.PreSchool == PreSchoolID).Select(m => m.Id).ToList();

            if (data != null)
            {
                var applications = _unitOfWork.ApplicationFormRepository.GetAndInclude(x => data.Contains(x.Id), null,
                    x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems);

                var counter = 1;
                foreach(var i in applications)
                {
                    ReviewViewModel reviewViewModel = new ReviewViewModel();
                    reviewViewModel.Id = i.Id;
                    reviewViewModel.applicationNo = counter.ToString();
                    reviewViewModel.parentName = i.parentParticularItems.ParentName1;
                    reviewViewModel.childName = i.childParticularItems.ChildName;
                    reviewViewModel.submissionDate = i.CreatedTimeStamp.ToShortDateString();
                    reviewViewModel.applicationStatus = i.ApplicationStatus.ToString();
                    results.Add(reviewViewModel);
                    counter++;
                }
            }
            
            return results;
        }

        public virtual async void ReviewApplication(int id,string action)
        {
            var application = _unitOfWork.ApplicationFormRepository.Get(c => c.Id == id).FirstOrDefault();

            if (application != null)
            {
                if (action.Equals("A"))
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Accepted;
                }
                else if (action.Equals("R"))
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Rejected;
                }
                else
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Pending;
                }
                _unitOfWork.ApplicationFormRepository.Update(application);
                _unitOfWork.Commit();
            }
            var maa = 0;
        }

        public virtual async Task<int> TotalApplications(string userId)
        {
            
            var aa =  _unitOfWork.ProcessedPreSchoolRepository.Get(c=> c.OperatorId == userId).ToArray().Length;
            return aa;
        }

        //public virtual async Task<int> getTotalSubmissions(string createdBy)
        //{
        //    return _unitOfWork.ApplicationFormRepository.Get(p => p.CreatedBy.Equals(createdBy) && p.Status == Core.Expansion.Enum.Status.Active).ToArray().Length;
        //}

        //public virtual async Task<int> getTotalAcceptances(string createdBy)
        //{
        //    return _unitOfWork.ApplicationFormRepository.Get(p => p.CreatedBy.Equals(createdBy) && (p.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Approved || p.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Accepted)).ToArray().Length;
        //}


    }
}
