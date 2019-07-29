namespace GolfClubAdminWebSite.Areas.MatchSecretary.Models
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class GetTournamentListViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public String Format { get; set; }

        /// <summary>
        /// Gets or sets the name of the measured course.
        /// </summary>
        /// <value>
        /// The name of the measured course.
        /// </value>
        public String MeasuredCourseName { get; set; }

        /// <summary>
        /// Gets or sets the measured course tee colour.
        /// </summary>
        /// <value>
        /// The measured course tee colour.
        /// </value>
        public String MeasuredCourseTeeColour { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the player category.
        /// </summary>
        /// <value>
        /// The player category.
        /// </value>
        public String PlayerCategory { get; set; }

        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public String Status { get; set; }

        #endregion
    }
}