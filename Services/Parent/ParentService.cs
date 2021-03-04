﻿using Core.Domain.Form;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using System.Collections.Generic;
using DAL.Entities.Form;
using DAL.Entities;
using System;
using System.Linq;

namespace Services.Parent
{
    public partial class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ParentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual void SubmitApplicationForm(AdmissionModel admissionModel)
        {
            _unitOfWork.ApplicationFormRepository.Insert(_mapper.Map<ApplicationForm>(admissionModel));
            _unitOfWork.Commit();
        }

        public virtual async Task<AdmissionModel> EditApplicationForm(string encId)
        {
            return _mapper.Map<AdmissionModel>(_unitOfWork.ApplicationFormRepository.
                GetAndInclude(x => x.Id == Convert.ToInt32(encId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems).FirstOrDefault());

        }

        public virtual void EditApplicationForm(AdmissionModel editmodel)
        {
            _unitOfWork.ApplicationFormRepository.Update(_mapper.Map<ApplicationForm>(editmodel));
            _unitOfWork.Commit();
        }

        public virtual async Task<List<AdmissionModel>> ViewAllApplication(string userId)
        {
            var test = _unitOfWork.ApplicationFormRepository.GetAndInclude(x => x.CreatedBy.Equals(userId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems);
            var test2 = _mapper.Map<List<AdmissionModel>>(_unitOfWork.ApplicationFormRepository.
                GetAndInclude(x => x.CreatedBy.Equals(userId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems));
            return _mapper.Map<List<AdmissionModel>>(_unitOfWork.ApplicationFormRepository.
                GetAndInclude(x => x.CreatedBy.Equals(userId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems));
        }

        //public virtual async Task<AdmissionModel> ViewApplicationForm(string encId)
        //{
        //    return new AdmissionModel();
        //}

        //public virtual async Task<string> ActionToOffer(string encId)
        //{
        //    return "";
        //}

        //public virtual async Task<AdmissionModel> ActionToOffer(Boolean isAccpet)
        //{
        //    return new AdmissionModel();
        //}

        //public virtual async Task<string> Search(string encId)
        //{
        //    return "";
        //}

        //public virtual async Task<SearchModel> Search(SearchModel model)
        //{
        //    return new SearchModel();
        //}
    }
}
