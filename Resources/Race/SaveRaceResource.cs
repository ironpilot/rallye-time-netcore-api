using System.Collections.Generic;

namespace RallyeTime.Resources.Race
{
    public class SaveRaceResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CheckpointResource> Checkpoints { get; set; }

        public string AccessCode { get; set; }

        public SaveRaceResource()
        {
            Checkpoints = new List<CheckpointResource>();
        }
    }
}