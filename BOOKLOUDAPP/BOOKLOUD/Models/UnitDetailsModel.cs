using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UnitDetailsModel
    {
        public int Id { get; set; }
        public string UnitName { get; set; }

        public virtual CourseDetailsModel Course { get; set; }
    }
}
