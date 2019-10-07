using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UnitDetailsModel
    {
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public virtual CourseDetailsModel Course { get; set; }
        public virtual UniversityDetailsModel University { get; set; }

    }

    public class UnitDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Unit Code length can't be more than 10 letters.")]
        public string UnitCode { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Unit Name length can't be more than 25 letters.")]
        public string UnitName { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int UniversityId { get; set; }

    }
}
