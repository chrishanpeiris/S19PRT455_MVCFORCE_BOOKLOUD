using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UniversityDetailsViewModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public virtual ICollection<CourseDetailsViewModel> Course { get; set; }
    }
}
