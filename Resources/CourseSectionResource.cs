using System;
using System.ComponentModel.DataAnnotations;

namespace RallyeTime.Resources
{
    public class CourseSectionResource
    {
        public int Id { get; set; }
        
        public DateTime? TimeOut { get; set; }

        public DateTime? TimeIn { get; set; }

        [Required]
        public string TimeTrue { get; set; }

        [Required]
        public string TimeActual { get; set; }

        [Required]
        public string TimeError { get; set; }

        public int? Points { get; set; }
    }
}