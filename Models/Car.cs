using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RallyeTime.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Driver { get; set; }

        [Required]
        [StringLength(100)]
        public string Navigator { get; set; }

        [Required]
        [StringLength(5)]
        public string Number { get; set; }

        public ICollection<CourseSection> CourseSections { get; set; }

        public Car()
        {
            CourseSections = new List<CourseSection>();
        }
    }
}