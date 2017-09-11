using System.Collections.Generic;

namespace RallyeTime.Resources
{
    public class RaceResource
    {
        public int Id { get; }

        public string Name { get; set; }

        public IList<CheckpointResource> Checkpoints { get; set; }

        public string AccessCode { get; set; }

        public RaceResource()
        {
            Checkpoints = new List<CheckpointResource>();
        }
    }
}