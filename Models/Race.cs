using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RallyeTime.Models
{
    public class Race
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        
        public IList<Checkpoint> Checkpoints { get; set; }

        [Required]
        [StringLength(250)]
        public string AccessCode { get; set; }

        public Race()
        {
            Checkpoints = new List<Checkpoint>();
        }
    }
}