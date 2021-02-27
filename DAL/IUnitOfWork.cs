using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CentreServices> CentreServicesRepository { get; }
        IRepository<EnrolementRatio> EnrolementRatioRepository { get; }
        IRepository<KindergartenEnrolement> KindergartenEnrolementRepository { get; }
        void Commit();
    }
}
