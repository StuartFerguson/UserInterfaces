namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class MeasuredCourseListViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public String Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the standard scratch score.
        /// </summary>
        /// <value>
        /// The standard scratch score.
        /// </value>
        public Int32 StandardScratchScore { get; set; }

        /// <summary>
        /// Gets or sets the tee colour.
        /// </summary>
        /// <value>
        /// The tee colour.
        /// </value>
        public String TeeColour { get; set; }

        #endregion
    }
}