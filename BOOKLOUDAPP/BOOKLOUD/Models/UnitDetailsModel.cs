using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UnitDetailsModel
    {
        public int Id { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public virtual CourseDetailsModel Course { get; set; }

        public virtual UniversityDetailsModel University { get; set; }

    }

    public class UnitDetailsViewModel
    {
        public int Id { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public int CourseId { get; set; }

        public int UniversityId { get; set; }

    }
}
