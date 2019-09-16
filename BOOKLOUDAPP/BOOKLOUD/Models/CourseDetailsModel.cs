using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class CourseDetailsModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public virtual UniversityDetailsModel University { get; set; }

        public virtual ICollection<UnitDetailsModel> Unit { get; set; }
    }
}
