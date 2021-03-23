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
using Core.Domain.Email;
using Services.Email;

namespace Services.Operator 
{
    public partial class OperatorService : IOperatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public OperatorService(IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
        }

        public virtual async Task<List<ReviewViewModel>> RetrieveApplications(string userId)
        {
            var results = new List<ReviewViewModel>();

            var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
            var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
            var applications = _unitOfWork.ApplicationFormRepository.GetAndInclude(c => general.Contains(c.generalInformationItemsId) && 
            c.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Pending, null,
                    x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems).ToList();

   
            var counter = 1;
            foreach (var i in applications)
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

            return results;
        }

        public virtual async void ReviewApplication(int id,string action)
        {
            //var application = _unitOfWork.ApplicationFormRepository.Get(c => c.Id == id).FirstOrDefault();

            var application = _unitOfWork.ApplicationFormRepository.GetAndInclude(c => c.Id == id, null,
                    x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems).FirstOrDefault();

            if (application != null)
            {
                if (action.Equals("A"))
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Accepted;
                    _unitOfWork.ApplicationFormRepository.Update(application);
                    _unitOfWork.Commit();
                    await sendEmailAsync(application);
                }
                else if (action.Equals("R"))
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Rejected;
                    _unitOfWork.ApplicationFormRepository.Update(application);
                    _unitOfWork.Commit();
                    await sendEmailAsync(application);
                }
                else
                {
                    application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Pending;
                }
                
                //
            }
        }

        public virtual async Task<int> TotalApplications(string userId)
        {

            var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
            var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
            var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.Status == Core.Expansion.Enum.Status.Active).ToList();
            var count = applications.Count();

            return count;
        }

        //TotalAccepted
        public virtual async Task<int> TotalAccepted(string userId)
        {
            var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c=> c.Id).ToList();
            var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
            var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Accepted).ToList();
            var count = applications.Count();
            return count;
        }

        //TotalPending
        public virtual async Task<int> TotalPending(string userId)
        {
            var preschools = _unitOfWork.ProcessedPreSchoolRepository.Get(c => c.OperatorId == userId).Select(c => c.Id).ToList();
            var general = _unitOfWork.GeneralInformationItemsRepository.Get(c => preschools.Contains(c.PreSchool.Value)).Select(c => c.Id).ToList();
            var applications = _unitOfWork.ApplicationFormRepository.Get(c => general.Contains(c.generalInformationItemsId) && c.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Pending).ToList();
            var count = applications.Count();
            return count;
        }

        public virtual async Task sendEmailAsync(ApplicationForm application)
        {
            string Email = application.parentParticularItems.Email1;
            
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            //mailRequest.ToEmail = "koolexplorer123@gmail.com";
            //mailRequest.ToEmail = "wenjunn11@gmail.com";
            mailRequest.Subject = string.Format("Application has been reviewed by Operator !");
            mailRequest.Body = string.Format("We are pleased to inform you that operator has successfully reviewed your pre-school application." + 
                                              "The status of your application is {0}", application.ApplicationStatus + 
                                              ". Thank you for using KoolExplorer as your one-stop portal for the early childhood education system!");
            await _mailService.SendEmailAsync(mailRequest);
        }

    }
}
