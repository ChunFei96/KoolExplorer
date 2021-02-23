using Core.Domain.GovAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;
        private readonly IRepository<CentreServices> _centreServicesRepository;
        public UnitOfWork(EFDbContext context,
            IRepository<CentreServices> centreServicesRepository)
        {
            _context = context;
            _centreServicesRepository = centreServicesRepository;
        }

        public IRepository<CentreServices> CentreServicesRepository => _centreServicesRepository;

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
