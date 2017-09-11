using AutoMapper;
using RallyeTime.Resources;
using RallyeTime.Models;

namespace RallyeTime.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Race, RaceResource>();
            CreateMap<Checkpoint, CheckpointResource>();
        }
    }
}