using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.MockDatabase.Database.Models
{
    public class GolfClub
    {
        public Guid GolfClubId { get; set; }
        public String Name { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String Town { get; set; }
        public String Region { get; set; }
        public String PostalCode { get; set; }
        public String TelephoneNumber { get; set; }
        public String Website { get; set; }
        public String EmailAddress { get; set; }
    }
}
