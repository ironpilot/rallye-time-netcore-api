using System.Collections.Generic;

namespace RallyeTime.Resources.Race
{
    public class RaceResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CheckpointResource> Checkpoints { get; set; }

        public RaceResource()
        {
            Checkpoints = new List<CheckpointResource>();
        }
    }
}