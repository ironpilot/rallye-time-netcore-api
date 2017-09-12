using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RallyeTime.Resources
{
    public class CarResource
    {
        public int Id { get; set; }

        [Required]
        public string Driver { get; set; }

        [Required]
        public string Navigator { get; set; }

        [Required]
        public string Number { get; set; }

        public ICollection<CourseSectionResource> CourseSections { get; set; }

        public CarResource()
        {
            CourseSections = new List<CourseSectionResource>();
        }
    }
}