using AutoMapper;
using ShipManagement.Application.Dtos;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Profiles
{
    /// <summary>
    /// Mapping profile from Manager Entity to Manager Dto
    /// </summary>
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<Manager, ManagerDto>()
                .ForMember(dest => dest.Username, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, act => act.Ignore()); //Don't collect the password from Db to web client.

            CreateMap<ManagerDto, Manager>()
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Username));
        }
    }
}
