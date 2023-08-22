using MediatR;
using ShipManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Queries
{
    public class AuthenticateQuery :IRequest<ManagerDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
