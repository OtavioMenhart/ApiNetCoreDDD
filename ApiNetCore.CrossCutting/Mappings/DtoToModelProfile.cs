using ApiNetCore.Domain.Dtos.User;
using ApiNetCore.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}
