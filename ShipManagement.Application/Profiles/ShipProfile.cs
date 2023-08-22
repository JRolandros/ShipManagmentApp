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
    /// Mapping Ship from Ship Entity to Ship Dto
    /// </summary>
    public class ShipProfile : Profile
    {
        public ShipProfile()
        {
            CreateMap<Ship, ShipDto>(); // Everything matches perfectly
            CreateMap<ShipDto, Ship>()
                .ForMember(dest => dest.ManagerId, act => act.MapFrom(src => src.Manager.Id)) //Web client doesn't have relational property but has navigation property.So we have to set it for entity
                .ForMember(dest => dest.Manager, act => act.Ignore());
        }
    }
}
