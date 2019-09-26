using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.DataAccessLayer.Models
{
    public class CourseDetailsDALModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public virtual UniversityDetailsDALModel University { get; set; }

        public virtual ICollection<UnitDetailsDALModel> Unit { get; set; }
    }


    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public int UniversityId { get; set; }

    }


}
