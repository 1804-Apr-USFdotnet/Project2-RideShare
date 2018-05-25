using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using RideAlongAPI.Core.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<RideAlongAPI.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RideAlongAPI.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Shares.AddOrUpdate<Share>(x => x.Id,
                new Share { Id = 1, Seats = 3, DestinationCity = "Orlando", DepartureCity = "Tampa", DepartureDate = new DateTime(2018, 5, 26, 16, 30, 0) },
                new Share { Id = 2, Seats =2, DestinationCity = "Minas Tirith", DepartureCity = "Erebor", DepartureDate = new DateTime(2012, 2, 4, 0, 0, 0)},
                new Share { Id = 3, Seats = 1, DestinationCity = "Numenor", DepartureCity = "Westernesse", DepartureDate = new DateTime(1995, 4, 1, 6, 0, 0) }
            );
        }
    }
}
