namespace GolfHandicapMobile.MockAPI.DataTransferObjects
{
    using System;

    public class GetPlayerDetailsResponse
    {
        public DateTime DateOfBirth { get; set; }

        public String EmailAddress { get; set; }

        public Decimal ExactHandicap { get; set; }

        public String FirstName { get; set; }

        public String FullName { get; set; }

        public String Gender { get; set; }

        public Int32 HandicapCategory { get; set; }

        public Boolean HasBeenRegistered { get; set; }

        public String LastName { get; set; }

        public String MiddleName { get; set; }

        public Int32 PlayingHandicap { get; set; }
    }
}