using Core.Domain.GovAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CentreServices> CentreServicesRepository { get; }
        void Commit();
    }
}
