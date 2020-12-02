using AutoMapper;

namespace RestfulAPI.Profiles
{
    public class CoursesProfile:Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course, Models.CoursesDto>();
        }
    }
}