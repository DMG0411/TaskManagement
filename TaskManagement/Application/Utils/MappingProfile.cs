using Application.DTOs;
using AutoMapper;
using Task = Domain.Entities.Task;

namespace Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}
