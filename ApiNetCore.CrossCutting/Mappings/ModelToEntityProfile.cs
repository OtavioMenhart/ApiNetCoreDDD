using ApiNetCore.Domain.Entities;
using ApiNetCore.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
