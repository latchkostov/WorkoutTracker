using AutoMapper;
using WorkoutTracker.Models.DTOs;
using WorkoutTracker.Models.Entities;

namespace WorkoutTracker.Infra
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Exercise, ExerciseDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name ))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(d => d.VideoLink, opt => opt.MapFrom(src => src.VideoLink))
                .ForMember(d => d.MuscleGroups, opt => opt.MapFrom(src => src.MuscleGroups));
            CreateMap<MuscleGroup, MuscleGroupDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
