using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Core.Repositories;

namespace RideAlongAPI.Persistence.Repositories
{
    public class SharesRepository : Repository<Share>, ISharesRepository
    {
        public SharesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public void Update(Share share)
        {
            var entityInDb = Context.Set<Share>().Find(share.Id);
            Context.Entry(entityInDb).CurrentValues.SetValues(share);
        }

        public IEnumerable<Share> GetDesiredShare(string startLocation, string goalLocation)
        {
            if (goalLocation != "empty")
            {
                return Context.Shares.Where(x => x.DestinationCity == goalLocation && x.DepartureCity == startLocation).ToList();
            }

            else if (goalLocation == "empty")
            {
                return Context.Shares.Where(x => x.DepartureCity == startLocation).ToList();
            }

            else
                return GetAll();

        }

       public IEnumerable<Share> GetDateDescending()
        {
            return Context.Shares.OrderByDescending(o => o.DepartureDate).ToList();
        }

        public IEnumerable<Share> GetSeatsDescending()
        {
            return Context.Shares.OrderByDescending(s => s.Seats).ToList();
        }

        public IEnumerable<Share> GetSearchConditions(string desiredText)
        {
            return Context.Shares.Where(x => x.DepartureCity.Contains(desiredText) || x.DestinationCity.Contains(desiredText) || x.Seats.ToString() == desiredText).ToList();
        }

        public IEnumerable<Share> GetDepartureCityWithMostShares()
        {
            var shares = Context.Shares.GroupBy(x => x.DepartureCity)
                .OrderByDescending(x => x.Count()).FirstOrDefault().ToList();
            return shares;
        }

        public IEnumerable<Share> GetDestinationCityWithMostShares()
        {
            var shares = Context.Shares.GroupBy(x => x.DestinationCity)
                .OrderByDescending(x => x.Count()).FirstOrDefault().ToList();
            return shares;
        }
    }
}