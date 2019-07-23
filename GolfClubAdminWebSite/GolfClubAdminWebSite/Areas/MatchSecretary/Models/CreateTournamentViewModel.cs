namespace GolfClubAdminWebSite.Areas.MatchSecretary.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateTournamentViewModel
    {
        [NotDefault]
        public DateTime? TournamentDate { get; set; }

        [NotDefault]
        public Guid MeasuredCourseId { get; set; }

        [Required]
        public String Name { get; set; }

        [NotDefault]
        public Int32 MemberCategory { get; set; }

        [NotDefault]
        public Int32 Format { get; set; }
    }

    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    //public class NotEmptyAttribute : ValidationAttribute
    //{
    //    public const string DefaultErrorMessage = "The {0} field must not be empty";
    //    public NotEmptyAttribute() : base(DefaultErrorMessage) { }

    //    public override bool IsValid(object value)
    //    {
    //        NotEmpty doesn't necessarily mean required
    //        if (value is null)
    //        {
    //            return true;
    //        }

    //        switch (value)
    //        {
    //            case Guid guid:
    //                return guid != Guid.Empty;
    //            default:
    //                return true;
    //        }
    //    }
    //}

    public class NotDefaultAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not have the default value";
        public NotDefaultAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            //NotDefault doesn't necessarily mean required
            if (value is null)
            {
                return true;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                return !value.Equals(defaultValue);
            }

            // non-null ref type
            return true;
        }
    }
}