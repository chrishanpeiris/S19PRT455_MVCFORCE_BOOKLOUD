using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UnitDetailsViewModel
    {
        public int Id { get; set; }

        public virtual ICollection<UnitDetailsViewModel> University { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public virtual CourseDetailsViewModel Course { get; set; }
    }
}
