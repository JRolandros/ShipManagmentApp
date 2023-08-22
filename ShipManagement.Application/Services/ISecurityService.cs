using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    public interface ISecurityService
    {
        string CreateToken(Manager user);
    }
}
