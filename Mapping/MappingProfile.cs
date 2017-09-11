using AutoMapper;
using RallyeTime.Resources;
using RallyeTime.Models;

namespace RallyeTime.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Model to Resource
            CreateMap<Race, RaceResource>();
            CreateMap<Checkpoint, CheckpointResource>();
            CreateMap<Car, CarResource>();
            CreateMap<CourseSection, CourseSectionResource >();

            //Resource to Model
            CreateMap<RaceResource, Race>();
            CreateMap<CheckpointResource, Checkpoint>();
            CreateMap<CarResource, Car>();
            CreateMap<CourseSectionResource, CourseSection>();
        }
    }
}