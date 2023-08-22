using MediatR;
using ShipManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Queries
{
    public class GetShipsQuery : IRequest<List<ShipDto>>
    {
        public int ? ShipNumber { get; set; }
        public string? ShipName { get; set; }
        public int? ManagerId { get; set; }
        public int Limit { get; set; } = 0;
        public int OffSet { get; set; } = 0;


    }
}
