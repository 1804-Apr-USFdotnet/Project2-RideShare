using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Core.Repositories;

namespace RideAlongAPI.Persistence.Repositories
{
    public class MembersRepository : Repository<Member>, IMembersRepository
    {
        public MembersRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}