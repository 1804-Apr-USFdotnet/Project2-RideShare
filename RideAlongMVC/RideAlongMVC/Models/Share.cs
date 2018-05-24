using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideAlongMVC.Models
{
    public class Share
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime DepartureDate { get; set; }
        //public User Driver { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}