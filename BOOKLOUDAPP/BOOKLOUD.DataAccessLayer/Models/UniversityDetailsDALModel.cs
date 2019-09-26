using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.DataAccessLayer.Models
{
    public class UniversityDetailsDALModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public virtual ICollection<CourseDetailsDALModel> Course { get; set; }
    }
}
