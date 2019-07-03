using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapMobile.MockAPI.DataTransferObjects
{
    public class GetGolfClubResponse
    {
        public Guid Id { get; set; }
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
