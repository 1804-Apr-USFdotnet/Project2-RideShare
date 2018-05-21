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

        public IEnumerable<Share> GetDesiredShare(string startLocation = "empty", string goalLocation = "empty")
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
                return Context.Shares.ToList();

        }

       public IEnumerable<Share> GetDateDescending()
        {
            return Context.Shares.OrderByDescending(o => o.DepartureDate).ToList();
        }

        public IEnumerable<Share> GetSeatsDescending()
        {
            return Context.Shares.OrderByDescending(s => s.Seats).ToList();
        }
    }
}