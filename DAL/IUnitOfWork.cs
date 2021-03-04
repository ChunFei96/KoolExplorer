using DAL.Entities;
using DAL.Entities.Form;
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
        IRepository<Centres> CentresRepository { get; }
        IRepository<ApplicationForm> ApplicationFormRepository { get; }
        IRepository<GeneralInformationItems> GeneralInformationItemsRepository { get; }
        IRepository<ParentParticularItems> ParentParticularItemsRepository { get; }
        IRepository<ChildParticularItems> ChildParticularItemsRepository { get; }
        void Commit();
    }
}
