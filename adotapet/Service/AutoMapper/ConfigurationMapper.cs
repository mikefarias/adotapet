using AutoMapper;
using Domain.Entities;
using Service.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class ConfigurationMapper: Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<Ong, OngViewModel>().ReverseMap();
        }

    }
}
