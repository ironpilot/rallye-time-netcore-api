using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RallyeTime.Models
{
    [Table("Checkpoints")]
    public class Checkpoint
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime? TimeOut { get; set; }

        public DateTime? TimeIn { get; set; }

        [StringLength(250)]
        public string TimeTrue { get; set; }

        [StringLength(250)]
        public string TimeActual { get; set; }

        [StringLength(250)]
        public string TimeError { get; set; }

        public int? Points { get; set; }
    }
}