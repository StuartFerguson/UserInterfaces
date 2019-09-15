namespace GolfHandicapMobile.ViewModels
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class MembershipViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date joined.
        /// </summary>
        /// <value>
        /// The date joined.
        /// </value>
        public DateTime DateJoined { get; set; }

        /// <summary>
        /// Gets or sets the golf club identifier.
        /// </summary>
        /// <value>
        /// The golf club identifier.
        /// </value>
        public Guid GolfClubId { get; set; }

        /// <summary>
        /// Gets or sets the name of the golf club.
        /// </summary>
        /// <value>
        /// The name of the golf club.
        /// </value>
        public String GolfClubName { get; set; }

        /// <summary>
        /// Gets or sets the membership identifier.
        /// </summary>
        /// <value>
        /// The membership identifier.
        /// </value>
        public Guid MembershipId { get; set; }

        /// <summary>
        /// Gets or sets the membership number.
        /// </summary>
        /// <value>
        /// The membership number.
        /// </value>
        public String MembershipNumber { get; set; }

        #endregion
    }
}