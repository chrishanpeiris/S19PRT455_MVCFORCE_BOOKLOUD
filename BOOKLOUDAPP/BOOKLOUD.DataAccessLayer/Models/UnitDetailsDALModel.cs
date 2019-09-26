using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.DataAccessLayer.Models
{
    public class UnitDetailsDALModel
    {
        public int Id { get; set; }

        public virtual ICollection<UnitDetailsDALModel> University { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public virtual CourseDetailsDALModel Course { get; set; }
    }
}
