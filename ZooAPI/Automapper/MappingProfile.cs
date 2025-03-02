using AutoMapper;
using ZooAPI.Application.Entities;
using ZooAPI.DTO.AnimalDTO;

namespace ZooAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, CreateAnimalViewModel>()
                .ReverseMap();
            CreateMap<Animal, EditAnimalViewModel>()
                .ReverseMap();
            CreateMap<Animal, IndexAnimalViewModel>()
                .ReverseMap();
        }
    }
}
