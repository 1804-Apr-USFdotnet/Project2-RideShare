using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RideAlongAPI.Core;
using RideAlongAPI.Core.Repositories;
using RideAlongAPI.Persistence.Repositories;

namespace RideAlongAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Shares = new SharesRepository(_context);
            Members = new MembersRepository(_context);
        }

        public ISharesRepository Shares { get; }
        public IMembersRepository Members { get; }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}