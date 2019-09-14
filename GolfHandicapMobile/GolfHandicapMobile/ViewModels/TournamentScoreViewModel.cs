namespace GolfHandicapMobile.ViewModels
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class TournamentScoreViewModel
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
        /// Gets or sets the CSS.
        /// </summary>
        /// <value>
        /// The CSS.
        /// </value>
        public Int32 CSS { get; set; }

        /// <summary>
        /// Gets or sets the gross score.
        /// </summary>
        /// <value>
        /// The gross score.
        /// </value>
        public Int32 GrossScore { get; set; }

        /// <summary>
        /// Gets or sets the net score.
        /// </summary>
        /// <value>
        /// The net score.
        /// </value>
        public Int32 NetScore { get; set; }

        /// <summary>
        /// Gets or sets the playing handicap.
        /// </summary>
        /// <value>
        /// The playing handicap.
        /// </value>
        public Int32 PlayingHandicap { get; set; }

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

        #endregion
    }
}