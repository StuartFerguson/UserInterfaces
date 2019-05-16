using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MeasuredCourseViewModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String TeeColour { get; set; }

        [Required]
        public Int32 StandardScratchScore { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber1Yards { get; set; }
        [Required]
        [Range(3,5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber1Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber1StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber2Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber2Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber2StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber3Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber3Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber3StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber4Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber4Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber4StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber5Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber5Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber5StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber6Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber6Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber6StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber7Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber7Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber7StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber8Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber8Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber8StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber9Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber9Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber9StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber10Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber10Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber10StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber11Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber11Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber11StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber12Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber12Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber12StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber13Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber13Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber13StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber14Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber14Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber14StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber15Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber15Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber15StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber16Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber16Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber16StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber17Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber17Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber17StrokeIndex { get; set; }

        [Required]
        [Range(1, 800, ErrorMessage = "The Yardage must be between 1 and 800")]
        public Int32 HoleNumber18Yards { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The Par must be between 3 and 5")]
        public Int32 HoleNumber18Par { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "The Stroke Index must be between 1 and 18")]
        public Int32 HoleNumber18StrokeIndex { get; set; }
    }
}
