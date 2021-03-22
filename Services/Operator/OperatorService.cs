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
                //results = _unitOfWork.ApplicationFormRepository.Get(c => data.Contains(c.Id)).ToList();

                //var r = _unitOfWork.ApplicationFormRepository.Get(c => data.Contains(c.Id)).ToList();

                var r = _unitOfWork.ApplicationFormRepository.GetAndInclude(x => data.Contains(x.Id), null,
                    x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems);

                var counter = 1;
                foreach(var i in r)
                {
                    ReviewViewModel reviewViewModel = new ReviewViewModel();
                    reviewViewModel.Id = i.Id;
                    reviewViewModel.applicationNo = counter.ToString();
                    reviewViewModel.parentName = i.parentParticularItems.ParentName1;
                    reviewViewModel.childName = i.childParticularItems.ChildName;
                    reviewViewModel.submissionDate = i.CreatedTimeStamp.ToShortDateString();
                    results.Add(reviewViewModel);
                    counter++;
                }

                // results =  _mapper.Map<List<AdmissionModel>>();
                var maa = 0;
            }
            
            return results;
        }
    }
}
