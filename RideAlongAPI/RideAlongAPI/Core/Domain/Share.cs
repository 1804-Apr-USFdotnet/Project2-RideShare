using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RideAlongAPI.Models;

namespace RideAlongAPI.Core.Domain
{
    public class Share : IWithId
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime DepartureDate { get; set; }
        public ApplicationUser Driver { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}