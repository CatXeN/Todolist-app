using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations;

namespace TodolistAppModels.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserInformation>().ReverseMap();
        }
    }
}
