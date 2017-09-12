using AutoMapper;
using RallyeTime.Resources;
using RallyeTime.Models;
using System.Linq;
using System.Collections.Generic;

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
            CreateMap<RaceResource, Race>()
                .ForMember(c => c.Id, o => o.Ignore());
            CreateMap<CheckpointResource, Checkpoint>()
                .ForMember(c => c.Id, o => o.Ignore());
            CreateMap<CarResource, Car>()
                .ForMember(c => c.Id, o => o.Ignore())
                .ForMember(c => c.CourseSections, o => o.Ignore())
                .AfterMap((resource, model) => {
                    //Remove
                    var removeList = model.CourseSections.Where(crs => !resource.CourseSections.Any(r => r.Id == crs.Id));
                    foreach (var crs in removeList)
                        model.CourseSections.Remove(crs);

                    //Add
                    var addedList = resource.CourseSections.Where(crs => model.CourseSections.Any(m => m.Id == crs.Id)).Select(crs => new CourseSection
                    {
                        //TODO map properties
                    });
                    foreach(var crs in addedList)
                        model.CourseSections.Add(crs);
                });
            CreateMap<CourseSectionResource, CourseSection>()
                .ForMember(c => c.Id, o => o.Ignore());
        }
    }
}