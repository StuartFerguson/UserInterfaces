namespace GolfHandicapMobile.ViewModels
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class TournamentSignInViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>
        /// The name of the course.
        /// </value>
        public String CourseName { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public String Format { get; set; }

        /// <summary>
        /// Gets or sets the tournament date.
        /// </summary>
        /// <value>
        /// The tournament date.
        /// </value>
        public DateTime TournamentDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the tournament.
        /// </summary>
        /// <value>
        /// The name of the tournament.
        /// </value>
        public String TournamentName { get; set; }

        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public Guid TournamentId { get; set; }

        #endregion
    }
}