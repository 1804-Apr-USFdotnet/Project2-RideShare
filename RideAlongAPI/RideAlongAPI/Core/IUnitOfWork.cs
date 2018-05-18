using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideAlongAPI.Core.Repositories;

namespace RideAlongAPI.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISharesRepository Shares { get; }
        int Complete();
    }
}
