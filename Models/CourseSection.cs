using System;
using System.ComponentModel.DataAnnotations;

namespace RallyeTime.Models
{
    public class CourseSection
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int CheckpointId { get; set; }

        public Checkpoint Checkpoint { get; set; }

        public DateTime? TimeOut { get; set; }

        public DateTime? TimeIn { get; set; }

        [StringLength(8)]
        public string TimeTrue { get; set; }

        [StringLength(8)]
        public string TimeActual { get; set; }

        [StringLength(8)]
        public string TimeError { get; set; }

        public int? Points { get; set; }
    }
}