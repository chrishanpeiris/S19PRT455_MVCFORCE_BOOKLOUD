using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKLOUD.Models
{
    public class UniversityDetailsModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "University Name length can't be more than 50 letters.")]
        public string UniversityName { get; set; }
        public virtual ICollection<CourseDetailsModel> Course { get; set; }
    }
}
