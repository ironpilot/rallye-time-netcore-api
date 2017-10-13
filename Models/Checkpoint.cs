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

        public Race Race { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}