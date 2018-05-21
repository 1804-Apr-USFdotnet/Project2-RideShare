using System.Collections.Generic;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Core.Repositories;

namespace RideAlongAPI.Core.Repositories
{
    public interface ISharesRepository : IRepository<Share>
    {
        IEnumerable<Share> GetDesiredShare(string startcity, string goalcity);
        IEnumerable<Share> GetSeatsDescending();
        IEnumerable<Share> GetDateDescending();

    }
}
