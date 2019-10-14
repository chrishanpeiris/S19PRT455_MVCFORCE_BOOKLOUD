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
        [StringLength(20, ErrorMessage = "Unit Code length can't be more than 20 letters.")]
        public string UnitCode { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Unit Name length can't be more than 50 letters.")]
        public string UnitName { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int UniversityId { get; set; }

    }
}
