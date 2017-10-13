using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RallyeTime.Resources.Race;

namespace RallyeTime.Resources.Car
{
    public class CarResource
    {
        public int Id { get; set; }

        public RaceResource Race { get; set; }

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