using Core.Domain.Form;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using System.Collections.Generic;
using DAL.Entities.Form;
using DAL.Entities;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Services.Email;
using Core.Domain.Email;
using Microsoft.AspNetCore.Identity;

namespace Services.Parent
{
    public partial class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ParentService(IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public virtual async Task SubmitApplicationFormAsync(AdmissionModel admissionModel)
        {
            _unitOfWork.ApplicationFormRepository.Insert(_mapper.Map<ApplicationForm>(admissionModel));
            _unitOfWork.Commit();

            string Email = admissionModel.ParentsParticularsViewModel.Email1;
            string PreSchool = _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.Id == admissionModel.GeneralInformationViewModel.PreSchool.Value).FirstOrDefault().Name;
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            mailRequest.Subject = string.Format("Successfully submitted application to {0} !", PreSchool);
            mailRequest.Body = string.Format("We are pleased to inform you that you have successfully submitted your pre-school application to {0}! {1} <br><br> {2} <br><br> {3}", 
                                              PreSchool,
                                              "Please allow the pre-school operator to get back to you as soon as possible.",
                                              "Meanwhile, you may continue submit application to your favourite pre-school centre but keep in mind that only 1 offer acceptance allowed.",
                                              "Thank you for using KoolExplorer as your one-stop portal for the early childhood education system!");
            await _mailService.SendEmailAsync(mailRequest);
        }

        public virtual async Task<AdmissionModel> EditApplicationForm(string encId)
        {
            return _mapper.Map<AdmissionModel>(_unitOfWork.ApplicationFormRepository.
                GetAndInclude(x => x.Id == Convert.ToInt32(encId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems).FirstOrDefault());

        }

        public virtual async Task EditApplicationForm(AdmissionModel editmodel)
        {
            _unitOfWork.ApplicationFormRepository.Update(_mapper.Map<ApplicationForm>(editmodel));
            _unitOfWork.Commit();

            string Email = editmodel.ParentsParticularsViewModel.Email1;
            string PreSchool = _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.Id == editmodel.GeneralInformationViewModel.PreSchool.Value).FirstOrDefault().Name;
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            mailRequest.Subject = string.Format("Successfully updated the application for {0} !", PreSchool);
            mailRequest.Body = string.Format("This email is to inform you that you have successfully updated your pre-school application for {0}! {1} <br><br> {2} <br><br> {3} <br><br> {4}",
                                              PreSchool,
                                              "Please allow the pre-school operator to review your updated application with extra time.",
                                              "Meanwhile, you may continue submit application to your favourite pre-school centre but keep in mind that only 1 offer acceptance allowed.",
                                              "However, if you have not done the action mentioned above, please contact our customer service for further clarification.",
                                              "Thank you for using KoolExplorer as your one-stop portal for the early childhood education system!");
            await _mailService.SendEmailAsync(mailRequest);
        }

        public virtual async Task<List<AdmissionModel>> ViewAllApplication(string userId)
        {
            return _mapper.Map<List<AdmissionModel>>(_unitOfWork.ApplicationFormRepository.
                GetAndInclude(x => x.CreatedBy.Equals(userId), null,
                x => x.generalInformationItems, x => x.parentParticularItems, x => x.childParticularItems));
        }

        public virtual async Task<int> getTotalSchools()
        {
            return _unitOfWork.ProcessedPreSchoolRepository.GetAll().ToArray().Length;
        }

        public virtual async Task<int> getTotalSubmissions(string createdBy)
        {
            return _unitOfWork.ApplicationFormRepository.Get(p => p.CreatedBy.Equals(createdBy) && p.Status == Core.Expansion.Enum.Status.Active).ToArray().Length;
        }

        public virtual async Task<int> getTotalAcceptances(string createdBy)
        {
            return _unitOfWork.ApplicationFormRepository.Get(p => p.CreatedBy.Equals(createdBy) && (p.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Approved || p.ApplicationStatus == Core.Expansion.Enum.ApplicationStatus.Accepted)).ToArray().Length;
        }

        public virtual async Task AcceptApplicationForm(string Id)
        {
            var application = _unitOfWork.ApplicationFormRepository.Get(a => a.Id == Convert.ToInt32(Id)).FirstOrDefault();

            application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Accepted;

            _unitOfWork.ApplicationFormRepository.Update(application);

            // auto reject other application
            foreach(var record in _unitOfWork.ApplicationFormRepository.GetAll())
            {
                if(record.Id  != Convert.ToInt32(Id))
                {
                    record.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Rejected;
                    _unitOfWork.ApplicationFormRepository.Update(record);
                }
            }

            _unitOfWork.Commit();

            string Email = _unitOfWork.ParentParticularItemsRepository.Get(p => p.Id == application.parentParticularItemsId).FirstOrDefault().Email1;
            int? PreSchoolId = _unitOfWork.GeneralInformationItemsRepository.Get(g => g.Id == application.generalInformationItemsId).FirstOrDefault().PreSchool.Value;
            string PreSchool = _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.Id == PreSchoolId).FirstOrDefault().Name;
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            mailRequest.Subject = string.Format("Congratulations! you have just accepted the pre-school offer from {0} !", PreSchool);
            mailRequest.Body = string.Format("This email is to inform you that you have accepted the pre-school offer from {0}! {1} <br><br> {2} <br><br> {3} <br><br> {4}",
                                              PreSchool,
                                              "Please allow the pre-school operator to contact you within the next few days.",
                                              "For your information, other submitted applications will be rejected automatically by our system.",
                                              "However, if you have not done the action mentioned above, please contact our customer service for further clarification.",
                                              "Thank you for using KoolExplorer as your one-stop portal for the early childhood education system!");
            await _mailService.SendEmailAsync(mailRequest);
        }

        public virtual async Task RejectApplicationForm(string Id)
        {
            var application = _unitOfWork.ApplicationFormRepository.Get(a => a.Id == Convert.ToInt32(Id)).FirstOrDefault();

            application.ApplicationStatus = Core.Expansion.Enum.ApplicationStatus.Rejected;

            _unitOfWork.ApplicationFormRepository.Update(application);

            _unitOfWork.Commit();

            string Email = _unitOfWork.ParentParticularItemsRepository.Get(p => p.Id == application.parentParticularItemsId).FirstOrDefault().Email1;
            int? PreSchoolId = _unitOfWork.GeneralInformationItemsRepository.Get(g => g.Id == application.generalInformationItemsId).FirstOrDefault().PreSchool.Value;
            string PreSchool = _unitOfWork.ProcessedPreSchoolRepository.Get(p => p.Id == PreSchoolId).FirstOrDefault().Name;
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = Email;
            mailRequest.Subject = string.Format("Successfully rejected the pre-school offer from {0} !", PreSchool);
            mailRequest.Body = string.Format("This email is to inform you that you have successfully rejected the pre-school offer from {0}! {1} <br><br> {2} <br><br> {3}",
                                              PreSchool,
                                              "Meanwhile, you may continue submit application to your favourite pre-school centre but keep in mind that only 1 offer acceptance allowed",
                                              "However, if you have not done the action mentioned above, please contact our customer service for further clarification.",
                                              "Thank you for using KoolExplorer as your one-stop portal for the early childhood education system!");
            await _mailService.SendEmailAsync(mailRequest);
        }


    }
}
