namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MeasuredCourseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the hole number10 par.
        /// </summary>
        /// <value>
        /// The hole number10 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber10Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number10 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number10 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber10StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number10 yards.
        /// </summary>
        /// <value>
        /// The hole number10 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber10Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number11 par.
        /// </summary>
        /// <value>
        /// The hole number11 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber11Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number11 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number11 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber11StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number11 yards.
        /// </summary>
        /// <value>
        /// The hole number11 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber11Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number12 par.
        /// </summary>
        /// <value>
        /// The hole number12 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber12Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number12 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number12 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber12StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number12 yards.
        /// </summary>
        /// <value>
        /// The hole number12 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber12Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number13 par.
        /// </summary>
        /// <value>
        /// The hole number13 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber13Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number13 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number13 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber13StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number13 yards.
        /// </summary>
        /// <value>
        /// The hole number13 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber13Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number14 par.
        /// </summary>
        /// <value>
        /// The hole number14 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber14Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number14 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number14 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber14StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number14 yards.
        /// </summary>
        /// <value>
        /// The hole number14 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber14Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number15 par.
        /// </summary>
        /// <value>
        /// The hole number15 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber15Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number15 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number15 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber15StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number15 yards.
        /// </summary>
        /// <value>
        /// The hole number15 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber15Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number16 par.
        /// </summary>
        /// <value>
        /// The hole number16 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber16Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number16 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number16 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber16StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number16 yards.
        /// </summary>
        /// <value>
        /// The hole number16 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber16Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number17 par.
        /// </summary>
        /// <value>
        /// The hole number17 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber17Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number17 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number17 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber17StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number17 yards.
        /// </summary>
        /// <value>
        /// The hole number17 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber17Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number18 par.
        /// </summary>
        /// <value>
        /// The hole number18 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber18Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number18 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number18 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber18StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number18 yards.
        /// </summary>
        /// <value>
        /// The hole number18 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber18Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number1 par.
        /// </summary>
        /// <value>
        /// The hole number1 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber1Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number1 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number1 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber1StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number1 yards.
        /// </summary>
        /// <value>
        /// The hole number1 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber1Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number2 par.
        /// </summary>
        /// <value>
        /// The hole number2 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber2Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number2 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number2 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber2StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number2 yards.
        /// </summary>
        /// <value>
        /// The hole number2 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber2Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number3 par.
        /// </summary>
        /// <value>
        /// The hole number3 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber3Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number3 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number3 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber3StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number3 yards.
        /// </summary>
        /// <value>
        /// The hole number3 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber3Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number4 par.
        /// </summary>
        /// <value>
        /// The hole number4 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber4Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number4 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number4 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber4StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number4 yards.
        /// </summary>
        /// <value>
        /// The hole number4 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber4Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number5 par.
        /// </summary>
        /// <value>
        /// The hole number5 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber5Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number5 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number5 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber5StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number5 yards.
        /// </summary>
        /// <value>
        /// The hole number5 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber5Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number6 par.
        /// </summary>
        /// <value>
        /// The hole number6 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber6Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number6 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number6 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber6StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number6 yards.
        /// </summary>
        /// <value>
        /// The hole number6 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber6Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number7 par.
        /// </summary>
        /// <value>
        /// The hole number7 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber7Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number7 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number7 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber7StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number7 yards.
        /// </summary>
        /// <value>
        /// The hole number7 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber7Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number8 par.
        /// </summary>
        /// <value>
        /// The hole number8 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber8Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number8 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number8 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber8StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number8 yards.
        /// </summary>
        /// <value>
        /// The hole number8 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber8Yards { get; set; }

        /// <summary>
        /// Gets or sets the hole number9 par.
        /// </summary>
        /// <value>
        /// The hole number9 par.
        /// </value>
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber9Par { get; set; }

        /// <summary>
        /// Gets or sets the index of the hole number9 stroke.
        /// </summary>
        /// <value>
        /// The index of the hole number9 stroke.
        /// </value>
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber9StrokeIndex { get; set; }

        /// <summary>
        /// Gets or sets the hole number9 yards.
        /// </summary>
        /// <value>
        /// The hole number9 yards.
        /// </value>
        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber9Yards { get; set; }

        /// <summary>
        /// Gets or sets the measured course identifier.
        /// </summary>
        /// <value>
        /// The measured course identifier.
        /// </value>
        [Required]
        public Guid MeasuredCourseId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the standard scratch score.
        /// </summary>
        /// <value>
        /// The standard scratch score.
        /// </value>
        [Required]
        public Int32 StandardScratchScore { get; set; }

        /// <summary>
        /// Gets or sets the tee colour.
        /// </summary>
        /// <value>
        /// The tee colour.
        /// </value>
        [Required]
        public String TeeColour { get; set; }

        #endregion
    }
}