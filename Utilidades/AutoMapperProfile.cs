using AutoMapper;
using NetAPI.Dtos;
using NetAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetAPI.Utilidades
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Nota, NotaDto>();
        }
        
    }
}
