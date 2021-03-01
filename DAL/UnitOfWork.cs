using DAL.Entities;
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


        public UnitOfWork(EFDbContext context,
            IRepository<CentreServices> centreServicesRepository, 
            IRepository<EnrolementRatio> enrolementRatioRepository, 
            IRepository<KindergartenEnrolement> kindergartenEnrolementRepository,
            IRepository<Centres> centresRepository)
        {
            _context = context;
            _centreServicesRepository = centreServicesRepository;
            _enrolementRatioRepository = enrolementRatioRepository;
            _kindergartenEnrolementRepository = kindergartenEnrolementRepository;
            _centresRepository = centresRepository;
        }

        public IRepository<CentreServices> CentreServicesRepository => _centreServicesRepository;
        public IRepository<EnrolementRatio> EnrolementRatioRepository => _enrolementRatioRepository;
        public IRepository<KindergartenEnrolement> KindergartenEnrolementRepository => _kindergartenEnrolementRepository;
        public IRepository<Centres> CentresRepository => _centresRepository;

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
