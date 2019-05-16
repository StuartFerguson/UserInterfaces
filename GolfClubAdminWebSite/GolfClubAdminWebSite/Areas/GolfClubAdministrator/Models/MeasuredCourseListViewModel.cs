using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubAdminWebSite.Areas.GolfClubAdministrator.Models
{
    public class MeasuredCourseListViewModel
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String TeeColour { get; set; }

        public Int32  StandardScratchScore { get; set; }
    }
}
