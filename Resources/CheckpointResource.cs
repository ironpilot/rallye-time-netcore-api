using System;

namespace RallyeTime.Resources
{
    public class CheckpointResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? TimeOut { get; set; }

        public DateTime? TimeIn { get; set; }

        public string TimeTrue { get; set; }

        public string TimeActual { get; set; }

        public string TimeError { get; set; }

        public int? Points { get; set; }
    }
}