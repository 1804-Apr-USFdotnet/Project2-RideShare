using System.Collections.Generic;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Core.Repositories;

namespace RideAlongAPI.Core.Repositories
{
    public interface ISharesRepository : IRepository<Share>
    {
        IEnumerable<Share> GetDesiredShare(string startCity, string goalCity);
        IEnumerable<Share> GetSeatsDescending();
        IEnumerable<Share> GetDateDescending();
        IEnumerable<Share> GetSearchConditions(string searchText);
        IEnumerable<Share> GetDepartureCityWithMostShares();
        IEnumerable<Share> GetDestinationCityWithMostShares();

        void Update(Share share);
    }
}
