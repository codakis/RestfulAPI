using AutoMapper;
using RestfulAPI.Helpers;

namespace RestfulAPI.Profiles
{
    public class AuthorsProfile: Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorsDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src=>$"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest=> dest.Age,
                    opt=>opt.MapFrom(src=> src.DateOfBirth.GetCurrentAge()));
        }
    }
}