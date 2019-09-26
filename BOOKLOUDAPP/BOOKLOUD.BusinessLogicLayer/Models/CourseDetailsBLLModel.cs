using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.BusinessLogicLayer.Models
{
    public class CourseDetailsBLLModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public virtual UniversityDetailsBLLModel University { get; set; }

        public virtual ICollection<UnitDetailsBLLModel> Unit { get; set; }
    }


    //public class CourseDetailsViewModel
    //{
    //    public int Id { get; set; }
    //    public string CourseName { get; set; }

    //    public int UniversityId { get; set; }

    //}


}
