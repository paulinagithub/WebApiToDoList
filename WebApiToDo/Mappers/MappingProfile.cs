using AutoMapper;
using System;
using WebApiToDo.Models;
using WebApiToDo.ModelsDTO;

namespace WebApiToDo.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ToDo Mapper
            CreateMap<ToDoModel, ToDoDTO>()
                 .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => Convert.ToBoolean(src.IsCompleted)));

            CreateMap<ToDoDTO, ToDoModel>()
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => Convert.ToInt32(src.IsCompleted)));
        }
    }
}
