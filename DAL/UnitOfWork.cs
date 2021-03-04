using DAL.Entities;
using DAL.Entities.Form;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;

        private readonly IRepository<CentreServices> _centreServicesRepository;
        private readonly IRepository<EnrolementRatio> _enrolementRatioRepository;
        private readonly IRepository<KindergartenEnrolement> _kindergartenEnrolementRepository;
        private readonly IRepository<Centres> _centresRepository;

        private readonly IRepository<ApplicationForm> _applicationFormRepository;
        private readonly IRepository<GeneralInformationItems> _generalInformationItemsRepository;
        private readonly IRepository<ParentParticularItems> _parentParticularItemsRepository;
        private readonly IRepository<ChildParticularItems> _childParticularItemsRepository;
        public UnitOfWork(EFDbContext context,
            IRepository<CentreServices> centreServicesRepository, 
            IRepository<EnrolementRatio> enrolementRatioRepository, 
            IRepository<KindergartenEnrolement> kindergartenEnrolementRepository,
            IRepository<Centres> centresRepository,
            IRepository<ApplicationForm> applicationFormRepository,
            IRepository<GeneralInformationItems> generalInformationItemsRepository,
            IRepository<ParentParticularItems> parentParticularItemsRepository,
            IRepository<ChildParticularItems> childParticularItemsRepository)
        {
            _context = context;
            _centreServicesRepository = centreServicesRepository;
            _enrolementRatioRepository = enrolementRatioRepository;
            _kindergartenEnrolementRepository = kindergartenEnrolementRepository;
            _centresRepository = centresRepository;

            _applicationFormRepository = applicationFormRepository;
            _generalInformationItemsRepository = generalInformationItemsRepository;
            _parentParticularItemsRepository = parentParticularItemsRepository;
            _childParticularItemsRepository = childParticularItemsRepository;
        }

        public IRepository<CentreServices> CentreServicesRepository => _centreServicesRepository;
        public IRepository<EnrolementRatio> EnrolementRatioRepository => _enrolementRatioRepository;
        public IRepository<KindergartenEnrolement> KindergartenEnrolementRepository => _kindergartenEnrolementRepository;
        public IRepository<Centres> CentresRepository => _centresRepository;

        public IRepository<ApplicationForm> ApplicationFormRepository => _applicationFormRepository;
        public IRepository<GeneralInformationItems> GeneralInformationItemsRepository => _generalInformationItemsRepository;
        public IRepository<ParentParticularItems> ParentParticularItemsRepository => _parentParticularItemsRepository;
        public IRepository<ChildParticularItems> ChildParticularItemsRepository => _childParticularItemsRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
