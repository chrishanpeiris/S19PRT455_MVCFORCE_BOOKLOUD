using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.BusinessLogicLayer.Models
{
    public class UnitDetailsBLLModel
    {
        public int Id { get; set; }

        public virtual ICollection<UnitDetailsBLLModel> University { get; set; }

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public virtual CourseDetailsBLLModel Course { get; set; }
    }
}
