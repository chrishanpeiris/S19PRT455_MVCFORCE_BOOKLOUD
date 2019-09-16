using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UniversityDetailsModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public virtual ICollection<CourseDetailsModel> Course { get; set; }
    }
}
