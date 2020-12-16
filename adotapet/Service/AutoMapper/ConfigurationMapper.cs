using AutoMapper;
using Domain.Entities;
using Service.Models;
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
            CreateMap<Pet, PetViewModel>().ReverseMap();
            CreateMap<Adotante, AdotanteViewModel>().ReverseMap();
            CreateMap<Entrevista, EntrevistaViewModel>().ReverseMap();
        }

    }
}
