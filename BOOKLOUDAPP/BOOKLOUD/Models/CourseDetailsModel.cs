using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class CourseDetailsModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        
        public virtual UniversityDetailsModel University { get; set; }

        public virtual ICollection<UnitDetailsModel> Unit { get; set; }
    }


    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "CourseName length can't be more than 25 letters.")]

        public int UniversityId { get; set; }


    }


}