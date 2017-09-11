using System.Collections.Generic;

namespace RallyeTime.Resources
{
    public class CarResource
    {
        public int Id { get; }

        public string Driver { get; set; }

        public string Navigator { get; set; }

        public string Number { get; set; }

        public ICollection<CourseSectionResource> CourseSections { get; set; }
    }
}