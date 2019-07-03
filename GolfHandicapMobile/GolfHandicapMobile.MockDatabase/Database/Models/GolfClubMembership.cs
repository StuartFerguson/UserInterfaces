namespace GolfHandicapMobile.MockDatabase.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GolfClubMembership
    {
        public Guid GolfClubId { get; set; }
        public String GolfClubName { get; set; }

        public Guid PlayerId { get; set; }
        
        [Key]
        public Guid MembershipId { get; set; }

        public String PlayerFullName { get; set; }

        public DateTime PlayerDateOfBirth { get; set; }

        public String PlayerGender { get; set; }

        public DateTime AcceptedDateTime { get; set; }
        public DateTime RejectionDateTime { get; set; }
        public DateTime RejectionMessage { get; set; }
    }
}