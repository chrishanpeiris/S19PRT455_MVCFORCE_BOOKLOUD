using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.BusinessLogicLayer.Models
{
    public class UniversityDetailsBLLModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public virtual ICollection<CourseDetailsBLLModel> Course { get; set; }
    }
}
