using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideAlongAPI.Core.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Share> Shares { get; set; }
    }
}